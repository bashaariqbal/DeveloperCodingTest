using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DeveloperCodingTest.Models;
using DeveloperCodingTest.IData;
using DeveloperCodingTest.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DeveloperCodingTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repository;
        public HomeController(ILogger<HomeController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async  Task<IActionResult> Index()
        {
            var viewModel = await MapPeopleVM();
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = await MapPersonVM(id.Value);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personToUpdate = await _repository.SelectByIdAsync<Person>(id.Value);
           
            if (await TryUpdateModelAsync<Person>(
                personToUpdate,
                "",
                p => p.ForeName, p => p.SurName, p => p.Email))
            {
                try
                {
                    await _repository.UpdateAsync<Person>(personToUpdate);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(personToUpdate);
        }

        public async Task<IActionResult> GetMemberships(int id)
        {
            var viewModel = await MapMembershipVM(id);

            ViewData["Name"] = viewModel.Count > 0 ? viewModel.FirstOrDefault().PersonName: "No Record Found";

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ForeName,SurName,Email")] PersonVM personVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var person = MapPerson(personVM);

                    await _repository.CreateAsync<Person>(person);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            return View(personVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<PersonVM> MapPersonVM(int id)
        {
            var person = await _repository.SelectByIdAsync<Person>(id);

            return new PersonVM()
            {
                Id = person.Id,
                ForeName = person.ForeName,
                SurName = person.SurName,
                Email = person.Email
            };
        }

        private async Task<List<PersonVM>> MapPeopleVM()
        {
            var people = await _repository.SelectAllAsync<Person>();

            return people.Select(p => new PersonVM { 
            Id = p.Id,
            ForeName = p.ForeName,
            SurName = p.SurName,
            Email = p.Email
            }).ToList();
        }

        private async Task<List<MembershipVM>> MapMembershipVM(int id)
        {
            List<MembershipVM> vm = new List<MembershipVM>();

            var allMemberships = await _repository.SelectAllAsync<Membership>();

            var personMemberships = allMemberships.Where(m => m.PersonId == id).ToList();

            if (personMemberships == null) return vm;

            foreach (var membership in personMemberships)
            {
                vm.Add(new MembershipVM 
                {
                    PersonId = membership.PersonId,
                    MembershipTypeId = membership.MembershipTypeId,
                    Number = membership.Number, 
                    AccountBalance = membership.AccountBalance,
                    MembershipType = await GetMembershipType(membership.MembershipTypeId),
                    PersonName = await GetPersonName(membership.PersonId)
                });
            }

            return vm;
        }

        private async Task<string> GetMembershipType(int membershipTypeId)
        {
            var type = await _repository.SelectByIdAsync<MembershipType>(membershipTypeId);

            return type.Description;
        }

        private async Task<string> GetPersonName(int personId)
        {
            var person = await _repository.SelectByIdAsync<Person>(personId);

            return string.Join(" ", person.ForeName, person.SurName);
        }

        private Person MapPerson(PersonVM personVM)
        {
            return new Person()
            {
                Id = personVM.Id,
                ForeName = personVM.ForeName,
                SurName = personVM.SurName,
                Email = personVM.Email
            };
        }
    }
}
