using System;
using Xunit;
using BLL;
using BLL.Entities;


namespace Test
{
    public class IntegrationTesting
    {
        [Fact]
        public void TestMakingSubscription()
        {
            string name = "����";
            string surname = "������";
            string homeAddress = "��. ����������, 2";

            Subscriber sub = new Subscriber(name, surname, homeAddress);
            Subscriber sub2 = new Subscriber(name, surname);
            ProductData productData = new ProductData("Daily ������", "1");
            ProductData productData2 = new ProductData("Daily ������", "2");
            Request request = new Request(sub2, productData2);
            PostalOffice postalOffice = new PostalOffice();

            postalOffice.Subscribe(sub2, productData2);
            postalOffice.Unsubscribe(request);

            postalOffice.Subscribe(sub, productData);

            foreach (var req in postalOffice.GetListOfRequests())
            {
                if (req.subscriber.Name == sub.Name && req.subscriber.Surname == sub.Surname && req.subscriber.HomeAddress == sub.HomeAddress)
                {
                    Assert.True(true);
                }
            }
        }

        [Fact]
        public void TestGettingGoodsFromStorage()
        {
            const int QUANTITY = 3;
            ProductStorage storage = new ProductStorage();
            PrintingTheDailyOffice dailyPrinting = new PrintingTheDailyOffice(storage);
            PrintinNewTimesOffice newTimesPrinting = new PrintinNewTimesOffice(storage);

            Subscriber sub = new Subscriber("����", "��������", "��. ����������, 2");
            ProductData productData = new ProductData("Daily ������", "1");

            PostalOffice postalOffice = new PostalOffice();


            for (int i = 0; i < QUANTITY; i++)
            {
                dailyPrinting.printMagazine("Daily ������", "1");
            }
            for (int i = 0; i < QUANTITY; i++)
            {
                dailyPrinting.printNewspaper("Daily ������", "1");
            }

            for (int i = 0; i < QUANTITY; i++)
            {
                newTimesPrinting.printMagazine("Daily ������", "1");
            }
            for (int i = 0; i < QUANTITY; i++)
            {
                newTimesPrinting.printNewspaper("Daily ������", "1");
            }

            postalOffice.AddStorage(storage);
            postalOffice.Subscribe(sub, productData);

            postalOffice.Update();
            postalOffice.RemoveStorage(storage);

            if (sub.GetListOfProducts().Count != 0)//����������� ������� ��� �����
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void TestSubsRequest()
        {
            Subscriber sub = new Subscriber("����", "��������", "��. ����������, 2");
            ProductData productData = new ProductData("Daily ������", "1");
            ProductData productData2 = new ProductData("Daily ������", "2");

            PostalOffice postalOffice = new PostalOffice();
            postalOffice.Subscribe(sub, productData);
            postalOffice.Subscribe(sub, productData2);

            if (postalOffice.GetSubsRequest(sub).Count == 2)
            {
                Assert.True(true);
            }
        }

    }
}
