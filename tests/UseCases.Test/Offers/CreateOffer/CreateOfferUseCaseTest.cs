﻿using Bogus;
using FluentAssertions;
using Moq;
using RocketSeatAuction.API.Communication.Requests;
using RocketSeatAuction.API.Contracts;
using RocketSeatAuction.API.Entities;
using RocketSeatAuction.API.Services;
using RocketSeatAuction.API.UseCases.Auctions.GetCurrent;
using RocketSeatAuction.API.UseCases.Auctions.Offers.CreateOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UseCases.Test.Offers.CreateOffer;
public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {

        //ARRANGE
        var request = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, f => f.Random.Decimal(1, 700)).Generate();
            
        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

        //ACT
        var act = () => useCase.Execute(itemId, request);

        //ASSERT
        act.Should().NotThrow(); 
        
    }
}
