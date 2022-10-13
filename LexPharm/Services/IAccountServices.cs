using LexPharm.Models;
using LexPharm.ViewModel;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LexPharm.Services
{
    public  interface IAccountServices
    {
        Task<ApplicationUser> UserApplicantService(ApplicationUserViewModel applicationUserViewModel);
        Task<ApplicationUser> DoctorApplicantService(ApplicationUserViewModel applicationUserViewModel);
        string UploadedFile(IFormFile filesUrl, string fileLocation);
        List<ApplicationUser> DoctorsList();
        List<Drugs> DrugList();
    }
}
