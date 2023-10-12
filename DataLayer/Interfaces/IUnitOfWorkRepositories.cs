﻿using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IUnitOfWorkRepositories
    {
        IGenericRepository<Blog> BlogRepository { get; }
        IGenericRepository<Contact> ContactRepository { get; }
        IGenericRepository<Package> PackageRepository { get; }
        IGenericRepository<PackageOrder> PackageOrderRepository { get; }
        IGenericRepository<HotelRoom> HotelRoomRepository { get; }
        IGenericRepository<ProviderService> ProviderServiceRepository { get; }
        IGenericRepository<Review> ReviewRepository { get; }
        IGenericRepository<RoomsOrder> RoomOrderRepository { get; }
    }
}
