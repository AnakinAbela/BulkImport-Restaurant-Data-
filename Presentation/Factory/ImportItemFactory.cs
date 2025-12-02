using DataAccess.Repositories;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Presentation.Factory
{
    public class ImportItemFactory
    {
        public IItemValidating Build(string json)
        {
            dynamic myBuiltObject = JsonConvert.DeserializeObject<dynamic>(json);
            if (myBuiltObject != null)
            {
                if (myBuiltObject.type == "restaurant")
                {
                    Restaurant r = JsonConvert.DeserializeObject<Restaurant>(json);
                    return r;
                }
                else if (myBuiltObject.type == "menuItem")
                {
                    MenuItem m = JsonConvert.DeserializeObject<MenuItem>(json);
                    return m;
                }
            }
            return null;
        }

        public List<IItemValidating> BuildList(string json)
        {
            var items = new List<IItemValidating>();

            dynamic jsonArray = JsonConvert.DeserializeObject<dynamic>(json);
            foreach (var itemJson in jsonArray)
            {
                string itemString = JsonConvert.SerializeObject(itemJson);
                IItemValidating builtItem = Build(itemString);
                if (builtItem != null)
                {
                    items.Add(builtItem);
                }
            }

            return items;
        }
    }
}