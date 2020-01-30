using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeduShopData.Models;
using TeduShopData.ViewModel;
using TeduShopData.ViewModel.Common;
using TeduShopData.ViewModel.Post;
using TeduShopData.ViewModel.Product;
using TeduShopData.ViewModel.System;

namespace TeduShopAPIDapperCore.Mapping
{
    public class DomainProfile: Profile
    {
        public DomainProfile()
        {
            CreateMap<Posts, PostViewModel>();
            CreateMap<PostCategories, PostCategoryViewModel>();
            CreateMap<Tags, TagViewModel>();
            CreateMap<ProductCategories, ProductCategoryViewModel>();
            CreateMap<Products, ProductViewModel>();
            CreateMap<ProductTags, ProductTagViewModel>();
            CreateMap<Footers, FooterViewModel>();
            CreateMap<Slides, SlideViewModel>();
            CreateMap<Pages, PageViewModel>();
            CreateMap<ContactDetails, ContactDetailViewModel>();
            CreateMap<AppRoles, ApplicationRoleViewModel>();
            CreateMap<AppUsers, AppUserViewModel>();
            CreateMap<Functions, FunctionViewModel>();
            CreateMap<Permissions, PermissionViewModel>();
            CreateMap<ProductImages, ProductImageViewModel>();
            CreateMap<ProductQuantities, ProductQuantityViewModel>();
            CreateMap<Colors, ColorViewModel>();
            CreateMap<Sizes, SizeViewModel>();
            CreateMap<Orders, OrderViewModel>();
            CreateMap<OrderDetails, OrderDetailViewModel>();
            CreateMap<Announcements, AnnouncementViewModel>();
            CreateMap<AnnouncementUsers, AnnouncementUserViewModel>();

        }
    }
}

