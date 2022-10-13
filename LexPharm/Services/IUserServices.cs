using LexPharm.Models;
using LexPharm.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexPharm.Services
{
    public interface IUserServices 
    {
        Task<ApplicationUser> FindByPhoneNumberAsync(string phoneNumber);
        List<DropdownEnumModel> GetDropDownEnumsList();
        Drugs DrugUpload(DrugViewModel drugmodel);
    }
}
