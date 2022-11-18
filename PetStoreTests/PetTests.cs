using System;
using System.Collections.Generic;
using System.Net;
using Applications.PetStore.Swagger.Api;
using Applications.PetStore.Swagger.Client;
using Applications.PetStore.Swagger.Model;
using NUnit.Framework;

namespace PetStoreTests;
public class PetTests : TestHelper
{
    readonly PetApi _PetApi = new PetApi(TestHelper.BasePath);

    private Pet Darth_Vader;

    [Test]
    [QaVerification.Grading]
    public void GetPetThatExists()
    {
        var pet = _PetApi.GetPetById(1);

        Assert.That(pet!.Id, Is.EqualTo(1));
    }

    [Test]
    [QaVerification.Grading]
    public void GetPetThatDoesNotExist()
    {
        Assert.Throws<ApiException>(() => _PetApi.GetPetById(99));
    }

    [Test]
    [QaVerification.Grading]
    public void AddPet()
    {
        Darth_Vader = new Pet(id: 69, name: "Darth Vader", photoUrls: new List<string>(), tags: new List<Tag>());

        _PetApi.AddPet(Darth_Vader);

        Assert.That(Darth_Vader, Is.EqualTo(_PetApi.GetPetById(69)));
    }

    [Test]
    [QaVerification.Grading]
    public void RemovePet()
    {
        _PetApi.DeletePet(69);
        Assert.Throws<ApiException>(() => _PetApi.GetPetById(69));
    }
}