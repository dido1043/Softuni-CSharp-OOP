using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Cocktails.Entities;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Models.Delicacies.Enitities;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths;
        public Controller()
        {
            booths = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            IBooth booth = new Booth(booths.Models.Count + 1, capacity);
            booths.AddModel(booth);
            return String.Format(OutputMessages.NewBoothAdded, booth.BoothId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            var currentBooth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            if (cocktailTypeName != nameof(MulledWine) && cocktailTypeName != nameof(Hibernation))
                return String.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            if (size != "Small" && size != "Middle" && size != "Large")
                return String.Format(OutputMessages.InvalidCocktailSize, size);


            if (currentBooth.CocktailMenu.Models.Any(x => x.Name == cocktailName) &&
                currentBooth.CocktailMenu.Models.Any(x => x.Size == size))
                return String.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);


            ICocktail cocktail = null;
            if (cocktailTypeName == nameof(MulledWine))
                cocktail = new MulledWine(cocktailName, size);
            else
                cocktail = new Hibernation(cocktailName, size);
            currentBooth.CocktailMenu.AddModel(cocktail);
            return String.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            var currentBooth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            if (currentBooth.DelicacyMenu.Models.Any(x => x.Name == delicacyName))
                return String.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);

            if (delicacyTypeName != nameof(Gingerbread) && delicacyTypeName != nameof(Stolen))
                return String.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            IDelicacy delicacy = null;
            if (delicacyTypeName == nameof(Gingerbread))
                delicacy = new Gingerbread(delicacyName);
            else
                delicacy = new Stolen(delicacyName);
            currentBooth.DelicacyMenu.AddModel(delicacy);
            return String.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);

        }

        public string BoothReport(int boothId)
        {
            var currentBooth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            return currentBooth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            var currentBooth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            var result = String.Format(OutputMessages.GetBill, $"{currentBooth.CurrentBill:f2}");
            currentBooth.Charge();
            currentBooth.ChangeStatus();

            return result + Environment.NewLine + String.Format(OutputMessages.BoothIsAvailable, boothId);
        }

        public string ReserveBooth(int countOfPeople)
        {
            var ordered = booths.Models.Where(x => x.IsReserved == false && x.Capacity >= countOfPeople)
                .OrderBy(x => x.Capacity).ThenByDescending(y => y.BoothId);
            var currentBooth = ordered.First();//!
            if (currentBooth == null)
                return String.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            currentBooth.ChangeStatus();
            return String.Format(OutputMessages.BoothReservedSuccessfully, currentBooth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            var currentBooth = booths.Models.First(x => x.BoothId == boothId);
            var token = order.Split('/');
            var itemTypeName = token[0];
            var itemName = token[1];
            var countOfOrderedPieces = int.Parse(token[2]);

            if (itemTypeName != nameof(MulledWine) &&
                itemTypeName != nameof(Hibernation) &&
                itemTypeName != nameof(Gingerbread) &&
                itemTypeName != nameof(Stolen))
            {
                return String.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if (!currentBooth.CocktailMenu.Models.Any(y => y.Name == itemName) &&
                !currentBooth.DelicacyMenu.Models.Any(x => x.Name == itemName))
            {
                return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }

            if (itemTypeName == nameof(MulledWine) ||
                itemTypeName == nameof(Hibernation))
            {
                var sizeOfTheCocktail = token[3];

                if (!currentBooth.CocktailMenu.Models.Any(x => x.GetType().Name == itemTypeName) &&
                    !currentBooth.CocktailMenu.Models.Any(x => x.Size == sizeOfTheCocktail))
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, sizeOfTheCocktail, itemName);
                }
                ICocktail cocktail = currentBooth.CocktailMenu.Models.First(x => x.Name == itemName);
                double sum = 0;
                if (cocktail.Size == "Small")
                    currentBooth.UpdateCurrentBill(cocktail.Price * countOfOrderedPieces * 0.33);
                else if (cocktail.Size == "Middle")
                    currentBooth.UpdateCurrentBill(cocktail.Price * countOfOrderedPieces*0.66);
                else
                    currentBooth.UpdateCurrentBill(cocktail.Price * countOfOrderedPieces);


                return String.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
            }
            else
            {
                if (!currentBooth.DelicacyMenu.Models.Any(x => x.Name == itemName))
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
                IDelicacy delicacy = currentBooth.DelicacyMenu.Models.First(x => x.Name == itemName);
                currentBooth.UpdateCurrentBill(delicacy.Price * countOfOrderedPieces);
                return String.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
            }
        }
    }
}
