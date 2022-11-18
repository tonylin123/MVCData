﻿using System;



namespace MVCData.ViewModels
{
    public class PCViewModels // "Container class" used by PeopleController to send multiple view models to view
    {
        public PeopleViewModel People { get; set; } = new();
        public CreatePersonViewModel CreatePerson { get; set; } = new();
    }
}
