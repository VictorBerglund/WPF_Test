﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Test.Models;

namespace WPF_Test.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
		private string _firstName = "Dick";
		private string _lastName;
		private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
		private PersonModel _selectedPerson;

		public ShellViewModel()
		{
			People.Add(new PersonModel { FirstName = "Obi-Wan", LastName = "Kenobi" });
			People.Add(new PersonModel { FirstName = "Qui-Gon", LastName = "Jin" });
			People.Add(new PersonModel { FirstName = "Darth", LastName = "Maul" });
		}

		public string FirstName
		{
			get { return _firstName; }
			set
			{
				_firstName = value;
				NotifyOfPropertyChange(() => FirstName);
				NotifyOfPropertyChange(() => FullName);
			}
		}

		public string LastName
		{
			get { return _lastName; }
			set
			{
				_lastName = value;
				NotifyOfPropertyChange(() => LastName);
				NotifyOfPropertyChange(() => FullName);
			}
		}

		public string FullName
		{
			get
			{
				return $"{FirstName} {LastName}";
			}
		}

		public BindableCollection<PersonModel> People
		{
			get { return _people; }
			set { _people = value; }
		}

		public PersonModel SelectedPerson
		{
			get { return _selectedPerson; }
			set
			{
				_selectedPerson = value;
				NotifyOfPropertyChange(() => SelectedPerson);
			}
		}

		public bool CanClearText(string firstName, string lastName) => !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);

		public void ClearText(string firstName, string lastName)
		{
			FirstName = "";
			LastName = "";
		}

		public void LoadPage()
		{
			ActivateItem(new FirstChildViewModel());
		}

		public void LoadPageTwo()
		{
			ActivateItem(new SecondChildViewModel());
		}
	}
}
