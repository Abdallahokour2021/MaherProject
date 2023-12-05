﻿using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ServiceLayer.Services
{
	public class PackageServices
    {
        private readonly IGenericRepository<Package> _packageRepository;
        private readonly ImageService _imageService;
        public static List<string> PackageImages = new List<string>()
            {
                "PackageImage1",
                "PackageImage2",
                "PackageImage3"
            };
        public static List<string> HotelImages = new List<string>()
            {
                "HotelImage1",
                "HotelImage2",
                "HotelImage3"
            };
        public PackageServices(IUnitOfWorkRepositories unitofworkRepository,ImageService imageService)
		{
			_packageRepository = unitofworkRepository.PackageRepository;
            _imageService = imageService;
		}

        public async Task<(IEnumerable<PackageDTO> EntityData, int Count)> ListWithPaging(
string orderBy, int? page, int? pageSize, bool isDescending)
        {
            Func<IQueryable<Package>, IOrderedQueryable<Package>> orderByExpression;

            switch (orderBy)
            {
                case "Id":
                    orderByExpression = query => isDescending ? query.OrderByDescending(entity => entity.Id) : query.OrderBy(entity => entity.Id);
                    break;
                case "Name":
                    orderByExpression = query => isDescending ? query.OrderByDescending(entity => entity.Name) : query.OrderBy(entity => entity.Name);
                    break;
                case "BlogMainText":
                    orderByExpression = query => isDescending ? query.OrderByDescending(entity => entity.Description) : query.OrderBy(entity => entity.Description);
                    break;
                case "Price":
                    orderByExpression = query => isDescending ? query.OrderByDescending(entity => entity.Price) : query.OrderBy(entity => entity.Price);
                    break;
                case "IsPublished":
                    orderByExpression = query => isDescending ? query.OrderByDescending(entity => entity.IsPublished) : query.OrderBy(entity => entity.IsPublished);
                    break;
                default:
                    orderByExpression = query => query.OrderBy(entity => entity.Id);
                    break;
            }

            (IList<Package> EntityData, int Count) = await _packageRepository.ListWithPaging(
                orderBy: orderByExpression,
                page: page,
                pageSize: pageSize,
                filter: null
            );

            IEnumerable<PackageDTO> results = EntityData.Select(x => new PackageDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                IsPublished = x.IsPublished,
            }).ToList();

            return (results, Count);
        }

        public async Task<PackageDTO> GetById(int Id)
        {
            var entity = await _packageRepository.GetById(Id);

            var data = new PackageDTO
            {
                Description = entity.Description,
                PackageMainImage = entity.PackageMainImage,
                PackageImage1 = entity.PackageImage1,

                PackageTypeId = entity.PackageTypeId,
                Name = entity.Name,
                Price = entity.Price,
                Discount = entity.Discount,
                IsPublished = entity.IsPublished,
                IsDeleted = entity.IsDeleted,
                NumberOfDays = entity.NumberOfDays,
                NumberOfNights = entity.NumberOfNights,
                UserId = entity.UserId
            };
            return data;
        }


        public async Task Edit(PackageDTO data)
        {
            var entity = await _packageRepository.GetById(data.Id);
            entity.Name = data.Name;
            entity.Description = data.Description;
            entity.PackageTypeId = data.PackageTypeId;

            entity.Price = data.Price;
            entity.Discount = data.Discount;

            entity.IsPublished = data.IsPublished;

            entity.IsDeleted = data.IsDeleted;


            entity.NumberOfDays = data.NumberOfDays;
            entity.NumberOfNights = data.NumberOfNights;
            entity.UserId = data.UserId;
            entity = await HandlePackageMultipleImages(entity, data);
            entity = await HandleHotelMultipleImages(entity, data);

            entity = await HandleImagesOC(entity, data, true);

            await _packageRepository.Edit(entity);
        }

       
        public async Task Delete(int Id)
        {
            var entity = await _packageRepository.GetById(Id);
            if (entity != null)
            {
                List<string> images = new List<string>();
                images.Add(entity.PackageMainImage);
                images.Add(entity.PackageImage1);
                images.ForEach(async image =>
                {
                    if (!string.IsNullOrEmpty(image))
                    {
                        FileManager.DeleteFile(image);
                    }
                });
                await _packageRepository.Delete(entity);
            }
        }

        public async Task Create(PackageDTO data)
        {
            var entity = new Package()
            {
                Description = data.Description,
                Name = data.Name,
                Price = data.Price,
                Discount = data.Discount,
                IsPublished = data.IsPublished,
                IsDeleted = data.IsDeleted,
                NumberOfDays = data.NumberOfDays,
                NumberOfNights = data.NumberOfNights,
                UserId = data.UserId
            };
            entity = await HandleImagesOC(entity, data,false);
            entity = await HandlePackageMultipleImages(entity, data);
            entity = await HandleHotelMultipleImages(entity, data);
            await _packageRepository.Add(entity);
        }

        public async Task<Package> HandleImagesOC(Package entity, PackageDTO data,bool IsEdit)
        {
            var imageDictionary = new Dictionary<string, IFormFile>
            {
                { "PackageMainImage", data.PackageMainImageFile },
                { "HotelMainImage", data.HotelMainImageFile },
            };

            foreach (var kvp in imageDictionary)
            {
                var propertyName = kvp.Key;

                if (kvp.Value != null)
                {
                    if (IsEdit)
                    {
                        var oldImage = entity.GetType().GetProperty(propertyName)?.GetValue(entity);
                        FileManager.DeleteFile(oldImage.ToString());
                    }
                    var uploadedImageUrl = await ImageService.UploadFile(kvp.Value);
                    entity.GetType().GetProperty(propertyName)?.SetValue(entity, uploadedImageUrl);
                }
            }
            return entity;
        }
        public async Task<Package> HandlePackageMultipleImages(Package entity, PackageDTO data, bool IsEdit=false)
        {
            int count = 0;
            if(data.PackageImages != null) 
            { 
                foreach (var kvp in data.PackageImages)
                {
                    var files = kvp;
                    var propertyName = PackageImages[count];
                    var oldImage = entity.GetType().GetProperty(propertyName)?.GetValue(entity);
                    if(oldImage != null)
                    {
                        FileManager.DeleteFile(oldImage.ToString());
                    }
                    if (files != null)
                    {
                        var uploadedImageUrl = await ImageService.UploadFile(kvp);
                        entity.GetType().GetProperty(propertyName)?.SetValue(entity, uploadedImageUrl);
                    }
                    count++;
                }
            }
            return entity;
        }
        public async Task<Package> HandleHotelMultipleImages(Package entity, PackageDTO data)
        {
            int count = 0;
            if(data.HotelImages != null)
            {
                foreach (var kvp in data.HotelImages)
                {
                    var files = kvp;
                    var propertyName = HotelImages[count];
                    var oldImage = entity.GetType().GetProperty(propertyName)?.GetValue(entity);
                    if(oldImage != null)
                    {
                        FileManager.DeleteFile(oldImage.ToString());
                    }
                    if (files != null)
                    {
                        var uploadedImageUrl = await ImageService.UploadFile(kvp);
                        entity.GetType().GetProperty(propertyName)?.SetValue(entity, uploadedImageUrl);
                    }
                    count++;
                }
            }
            return entity;
        }
    }
}
