using AutoMapper;
using Corbet.Application.Features.Categories.Commands.CreateCategory;
using Corbet.Application.Features.Categories.Commands.StoredProcedure;
using Corbet.Application.Features.Categories.Queries.GetCategoriesList;
using Corbet.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Corbet.Application.Features.Events.Commands.CreateEvent;
using Corbet.Application.Features.Events.Commands.Transaction;
using Corbet.Application.Features.Events.Commands.UpdateEvent;
using Corbet.Application.Features.Events.Queries.GetEventDetail;
using Corbet.Application.Features.Events.Queries.GetEventsExport;
using Corbet.Application.Features.Events.Queries.GetEventsList;
using Corbet.Application.Features.Orders.GetOrdersForMonth;
using Corbet.Application.Features.ProductCategory.Commands.CraeteProductCategory;
using Corbet.Application.Features.ProductCategory.Commands.CreateProductCategory;
using Corbet.Application.Features.ProductCategory.Commands.UpdateProductCategory;
using Corbet.Application.Features.ProductCategory.Queries.GetAllProductCategories;
using Corbet.Application.Features.ProductCategoryDetails.Commands.CreateCategoryDetails;
using Corbet.Application.Features.ProductCategoryDetails.Commands.DeletCategoryDetails;
using Corbet.Application.Features.ProductCategoryDetails.Commands.UpdateCategoryDetails;
using Corbet.Application.Features.ProductCategoryDetails.Queries.GetAllCategoryDetails;
using Corbet.Application.Features.Products.Commands.CreateProduct;
using Corbet.Application.Features.Products.Commands.UpdateProduct;
using Corbet.Application.Features.Products.Queries.GetAllProducts;
using Corbet.Application.Features.Roles.Commands.CreateRole;
using Corbet.Application.Features.Roles.Commands.UpdateRole;
using Corbet.Application.Features.Roles.Queries.GetAllRoles;
using Corbet.Application.Features.Suppliers.Commands.CreateSupplier;
using Corbet.Application.Features.Suppliers.Commands.UpdateSupplier;
using Corbet.Application.Features.Suppliers.Queries.GetAllSuppliers;
using Corbet.Application.Features.Taxes.Commands.CreateTax;
using Corbet.Application.Features.Taxes.Commands.CreateTaxDetail;
using Corbet.Application.Features.Taxes.Commands.UpdateTax;
using Corbet.Application.Features.Taxes.Commands.UpdateTaxDetail;
using Corbet.Application.Features.Taxes.Queries.GetAllTaxDetails;
using Corbet.Application.Features.Taxes.Queries.GetAllTaxes;
using Corbet.Application.Features.UnitMeasurements.Commands.CreateUnitMeasurement;
using Corbet.Application.Features.UnitMeasurements.Commands.DeleteUnitMeasurement;
using Corbet.Application.Features.UnitMeasurements.Commands.UpdateUnitMeasurement;
using Corbet.Application.Features.UnitMeasurements.Queries.GetAllUnitMeasurements;
using Corbet.Application.Features.UnitMeasurements.Queries.GetUnitMeasurementById;
using Corbet.Application.Features.Users.Commands.CreateUser;
using Corbet.Application.Features.Users.Commands.ResetPassword;
using Corbet.Application.Features.Users.Commands.UpdateUser;
using Corbet.Application.Features.Users.Queries.GetAllUsers;
using Corbet.Domain.Entities;

namespace Corbet.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, TransactionCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Category, StoredProcedureCommand>();
            CreateMap<Category, StoredProcedureDto>();

            CreateMap<Order, OrdersForMonthDto>();

            CreateMap<Event, EventListVm>().ConvertUsing<EventVmCustomMapper>();


            CreateMap<CreateRoleCommand, Role>();
            CreateMap<Role, CreateRoleDto>().ReverseMap();

            CreateMap<Role, GetRolesListQuery>().ReverseMap();
            CreateMap<Role, GetRolesListVm>().ReverseMap();

            CreateMap<Role, UpdateRoleCommand>().ReverseMap();
            CreateMap<Role, UpdateRoleCommandDto>().ReverseMap();


            CreateMap<GetAllUsersQuery, User>();
            CreateMap<User, GetUsersQueryVm>().ReverseMap();

            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, CreateUserCommandDto>().ReverseMap();

            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommandDto>().ReverseMap();

            CreateMap<User, ResetPasswordCommand>().ReverseMap();             
            CreateMap<User, ResetPasswordDto>().ReverseMap();


            CreateMap<Supplier, CreateSupplierCommand>().ReverseMap();
            CreateMap<Supplier, CreateSupplierCommandDto>().ReverseMap();

            CreateMap<Supplier, GetAllSuppliersQuery>().ReverseMap();
            CreateMap<Supplier, GetAllSuppliersQueryVm>().ReverseMap();

            CreateMap<Supplier, UpdateSupplierCommand>().ReverseMap();
            CreateMap<Supplier, UpdateSupplierCommandDto>().ReverseMap();
            CreateMap<Supplier, UpdateSupplierAdminCommand>().ReverseMap();
            CreateMap<Supplier, UpdateSupplierAdminCommandDto>().ReverseMap();

            CreateMap<Tax, GetAllTaxesQuery>().ReverseMap();
            CreateMap<Tax, GetAllTaxesVm>().ReverseMap();

            CreateMap<TaxDetail, GetAllTaxDetailsQuery>().ReverseMap();
            CreateMap<TaxDetail, GetAllTaxDetailsVm>().ReverseMap();

            CreateMap<Tax, CreateTaxCommand>().ReverseMap();
            CreateMap<Tax, CreateTaxDto>().ReverseMap();

            CreateMap<TaxDetail, CreateTaxDetailCommand>().ReverseMap();
            CreateMap<TaxDetail, CreateTaxDetailDto>().ReverseMap();

            CreateMap<Tax, UpdateTaxCommand>().ReverseMap();
            CreateMap<Tax, UpdateTaxDto>().ReverseMap();
            
            CreateMap<TaxDetail, UpdateTaxDetailCommand>().ReverseMap();
            CreateMap<TaxDetail, UpdateTaxDetailDto>().ReverseMap();


            CreateMap<CreateUnitMeasurementCommand, UnitMeasurement>();
            CreateMap<UnitMeasurement, CreateUnitMeasurementDto>();

            CreateMap<DeleteUnitMeasurementCommand, UnitMeasurement>();
            CreateMap<UnitMeasurement, DeleteUnitMeasurementDto>();
            
            CreateMap<UpdateUnitMeasurementDtoIn, UnitMeasurement>();
            CreateMap<UnitMeasurement, UpdateUnitMeasurementDtoOut>();
            
            CreateMap<UnitMeasurement, GetAllUnitMeasurementsVm>();

            CreateMap<GetUnitMeasurementByIdQuery, UnitMeasurement>();
            CreateMap<UnitMeasurement, GetUnitMeasurementByIdVm>();


            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, CreateProductCommandDto>().ReverseMap();

            CreateMap<Product, GetAllProductsQuery>().ReverseMap();
            CreateMap<Product, GetAllProductsVm>().ReverseMap();

            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommandDto>().ReverseMap();
            CreateMap<CreateProductCategoryCommand, Domain.Entities.ProductCategory>();
            CreateMap<Domain.Entities.ProductCategory, CreateProductCategoryCommandDto>();

            CreateMap<UpdateProductCategoryCommand, Domain.Entities.ProductCategory>();
            CreateMap<Domain.Entities.ProductCategory, UpdateProductCategoryCommandDto>();

            CreateMap<CreateCategoryDetailsCommand, ProductCategoryDetail>();
            CreateMap<ProductCategoryDetail, CreateCategoryDetailsCommandDto>();

            CreateMap<ProductCategory, GetAllProductCategoriesVm>();

            CreateMap<UpdateCategoryDetailsCommand, ProductCategoryDetail>();
            CreateMap<ProductCategoryDetail, UpdateCategoryDetailsCommandDto>();

            CreateMap<DeleteCategoryDetailsCommand, ProductCategoryDetail>();
            CreateMap<ProductCategoryDetail, DeleteCategoryDetailsCommandDto>();


            CreateMap<ProductCategoryDetail, GetAllCategoryDetailsQuery>().ReverseMap();
            CreateMap<ProductCategoryDetail, GetAllCategoryDetailsVm>().ReverseMap();

        }
    }
}
