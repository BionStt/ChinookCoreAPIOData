using System;
using ChinookCoreAPIOData.Domain.ApiModels;
using FluentValidation;

namespace ChinookCoreAPIOData.Domain.Validation
{
    public class AlbumApiModelValidator : AbstractValidator<AlbumApiModel>
    {
        public AlbumApiModelValidator()
        {
            RuleFor(album => album.Title).NotNull()
                .WithMessage("Title cannot be empty");
            RuleFor(album => album.Title).MaximumLength(160)
                .WithMessage("xxxxx");
            RuleFor(album => album.ArtistId).NotNull()
                .WithMessage("Album cannot be empty");
        }
    }

    public class ArtistApiModelValidator : AbstractValidator<ArtistApiModel>
    {
        public ArtistApiModelValidator()
        {
            RuleFor(artist => artist.Name).NotNull()
                .WithMessage("Name cannot be empty");
            RuleFor(artist => artist.Name).MaximumLength(120)
                .WithMessage("");
        }
    }


    public class CustomerApiModelValidator : AbstractValidator<CustomerApiModel>
    {
        public CustomerApiModelValidator()
        {
            RuleFor(customer => customer.FirstName).NotNull()
                .WithMessage("First name cannot be empty");
            RuleFor(customer => customer.FirstName).MaximumLength(40)
                .WithMessage("");
            RuleFor(customer => customer.LastName).NotNull()
                .WithMessage("Last name cannot be empty");
            RuleFor(customer => customer.LastName).MaximumLength(20)
                .WithMessage("");
            RuleFor(customer => customer.Company).MaximumLength(80)
                .WithMessage("");
            RuleFor(customer => customer.Address).MaximumLength(70)
                .WithMessage("");
            RuleFor(customer => customer.City).MaximumLength(40)
                .WithMessage("");
            RuleFor(customer => customer.State).MaximumLength(40)
                .WithMessage("");
            RuleFor(customer => customer.Country).MaximumLength(40)
                .WithMessage("");
            RuleFor(customer => customer.PostalCode).MaximumLength(10)
                .WithMessage("");
            RuleFor(customer => customer.Phone).MaximumLength(24)
                .WithMessage("");
            RuleFor(customer => customer.Fax).MaximumLength(24)
                .WithMessage("");
            RuleFor(customer => customer.Email).EmailAddress()
                .WithMessage("");
        }
    }

    public class EmployeeApiModelValidator : AbstractValidator<EmployeeApiModel>
    {
        public EmployeeApiModelValidator()
        {
            RuleFor(employee => employee.FirstName).NotNull()
                .WithMessage("First name cannot be empty");
            RuleFor(employee => employee.FirstName).MaximumLength(20)
                .WithMessage("");
            RuleFor(employee => employee.LastName).NotNull()
                .WithMessage("Last name cannot be empty");
            RuleFor(employee => employee.LastName).MaximumLength(20)
                .WithMessage("");
            
            RuleFor(employee => employee.Title).MaximumLength(30)
                .WithMessage("");
            RuleFor(employee => employee.Address).MaximumLength(70)
                .WithMessage("");
            RuleFor(employee => employee.City).MaximumLength(40)
                .WithMessage("");
            RuleFor(employee => employee.State).MaximumLength(40)
                .WithMessage("");
            RuleFor(employee => employee.Country).MaximumLength(40)
                .WithMessage("");
            RuleFor(employee => employee.PostalCode).MaximumLength(10)
                .WithMessage("");
            RuleFor(employee => employee.Phone).MaximumLength(24)
                .WithMessage("");
            RuleFor(employee => employee.Fax).MaximumLength(60)
                .WithMessage("");
        }
    }

    public class GenreApiModelValidator : AbstractValidator<GenreApiModel>
    {
        public GenreApiModelValidator()
        {
            RuleFor(genre => genre.Name).NotNull()
                .WithMessage("Name cannot be empty");
            RuleFor(genre => genre.Name).MaximumLength(120)
                .WithMessage("");
        }
    }

    public class InvoiceApiModelValidator : AbstractValidator<InvoiceApiModel>
    {
        public InvoiceApiModelValidator()
        {
            RuleFor(invoice => invoice.CustomerId).NotNull()
                .WithMessage("Customer cannot be empty");
            RuleFor(invoice => invoice.InvoiceDate).NotNull()
                .WithMessage("Invoice cannot be empty");

            RuleFor(invoice => invoice.BillingAddress).MaximumLength(70)
                .WithMessage("");
            RuleFor(invoice => invoice.BillingCity).MaximumLength(40)
                .WithMessage("");
            RuleFor(invoice => invoice.BillingCountry).MaximumLength(40)
                .WithMessage("");
            RuleFor(invoice => invoice.BillingState).MaximumLength(40)
                .WithMessage("");
            RuleFor(invoice => invoice.BillingPostalCode).MaximumLength(10)
                .WithMessage("");
            
            RuleFor(invoice => invoice.Total).GreaterThan(Decimal.Zero)
                .WithMessage("");
        }
    }

    public class InvoiceLineApiModelValidator : AbstractValidator<InvoiceLineApiModel>
    {
        public InvoiceLineApiModelValidator()
        {
            RuleFor(invoiceLine => invoiceLine.InvoiceId).NotNull()
                .WithMessage("Invoice cannot be empty");
            RuleFor(invoiceLine => invoiceLine.TrackId).NotNull()
                .WithMessage("Track cannot be empty");
            RuleFor(invoiceLine => invoiceLine.UnitPrice).GreaterThan(Decimal.Zero)
                .WithMessage("");
            RuleFor(invoiceLine => invoiceLine.Quantity).GreaterThan(0)
                .WithMessage("");
        }
    }

    public class MediaTypeApiModelValidator : AbstractValidator<MediaTypeApiModel>
    {
        public MediaTypeApiModelValidator()
        {
            RuleFor(mediaType => mediaType.Name).NotNull()
                .WithMessage("Name cannot be empty");
            RuleFor(mediaType => mediaType.Name).MaximumLength(120)
                .WithMessage("");
        }
    }

    public class PlaylistApiModelValidator : AbstractValidator<PlaylistApiModel>
    {
        public PlaylistApiModelValidator()
        {
            RuleFor(playList => playList.Name).NotNull()
                .WithMessage("Name cannot be empty");
            RuleFor(playList => playList.Name).MaximumLength(120)
                .WithMessage("");
        }
    }

    public class PlaylistTrackApiModelValidator : AbstractValidator<PlaylistTrackApiModel>
    {
        public PlaylistTrackApiModelValidator()
        {
            RuleFor(playListTrack => playListTrack.PlaylistId).NotNull()
                .WithMessage("Playlist cannot be empty");
            RuleFor(playListTrack => playListTrack.TrackId).NotNull()
                .WithMessage("Track cannot be empty");
        }
    }

    public class TrackApiModelValidator : AbstractValidator<TrackApiModel>
    {
        public TrackApiModelValidator()
        {
            RuleFor(track => track.Name).NotNull()
                .WithMessage("Name cannot be empty");
            RuleFor(track => track.Name).MaximumLength(20)
                .WithMessage("");
            
            RuleFor(track => track.AlbumId).NotNull()
                .WithMessage("Album cannot be empty");
            RuleFor(track => track.MediaTypeId).NotNull()
                .WithMessage("Media type cannot be empty");
            RuleFor(track => track.GenreId).NotNull()
                .WithMessage("Genre cannot be empty");
            
            RuleFor(track => track.Composer).MaximumLength(220)
                .WithMessage("");
            
            RuleFor(invoiceLine => invoiceLine.Milliseconds).GreaterThan(0)
                .WithMessage("");
            RuleFor(invoiceLine => invoiceLine.Bytes).GreaterThan(0)
                .WithMessage("");
            RuleFor(invoiceLine => invoiceLine.UnitPrice).GreaterThan(Decimal.Zero)
                .WithMessage("");
        }
    }
}