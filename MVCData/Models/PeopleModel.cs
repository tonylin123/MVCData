﻿using MVCData.ViewModels;

namespace MVCData.Models
{
    public static class PeopleModel
    {
        public static PeopleViewModel List()
        {
            PeopleViewModel viewModel = new()
            {
                List = PeopleData.List
            };

            return viewModel;
        }


        public static PeopleViewModel Search(string keyword)
        {
            PeopleViewModel viewModel = new()
            {
                Search = keyword,
                List = PeopleData.List.FindAll(person => ContainsKeyword(person, keyword))
            };

            return viewModel;
        }


        public static PeopleViewModel CreatePerson(CreatePersonViewModel person)
        {
            Person1 newPerson = new(person.Name, person.Phone, person.City);

            PeopleData.List.Add(newPerson);

            PeopleViewModel viewModel = new()
            {
                List = PeopleData.List
            };

            return viewModel;
        }


        public static PeopleViewModel DeletePerson(string name)
        {
            var person = PeopleData.List.FirstOrDefault(person => person.Name.ToLower() == name.ToLower());

            if (person != null)
            {
                PeopleData.List.Remove(person);
            }

            PeopleViewModel viewModel = new()
            {
                List = PeopleData.List
            };

            return viewModel;
        }


        private static bool ContainsKeyword(Person1 person, string keyword)
        {
            return HasName(person, keyword) || HasPhonenumber(person, keyword) || LivesInCity(person, keyword);
        }


        private static bool HasName(Person1 person, string name)
        {
            return person.Name.ToLower().Contains(name.ToLower());
        }


        private static bool HasPhonenumber(Person1 person, string phonenumber)
        {
            return person.Phone.ToLower().Contains(phonenumber.ToLower());
        }


        private static bool LivesInCity(Person1 person, string city)
        {
            return person.City.ToLower().Contains(city.ToLower());
        }
    }
}
