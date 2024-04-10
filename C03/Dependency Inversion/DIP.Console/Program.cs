using DependencyInversionPrinciple.Core;
using DependencyInversionPrinciple.Data.InMemory;
using System;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple.App
{
    internal class Program
    {
        private static readonly BookPresenter _presenter = new BookPresenter();

        private static async Task Main(string[] args)
        {
            var isPublic = args?.Length == 0 || args[0] != "admin";
            Console.WriteLine($"isPublic: {isPublic}");
            if (isPublic)
            {
                await PublicAppAsync();
            }
            else
            {
                await AdminAppAsync();
            }
            Console.ReadLine();
        }

        private static async Task PublicAppAsync()
        {
            var publicService = Composer.CreatePublicService();
            var books = await publicService.FindAllAsync();
            foreach (var book in books)
            {
                _presenter.Display(book);
            }
        }

        private static async Task AdminAppAsync()
        {
            var adminService = Composer.CreateAdminService();
            var books = await adminService.FindAllAsync();
            foreach (var book in books)
            {
                _presenter.Display(book);
            }
        }

        private static class Composer
        {
            private readonly static BookStore _bookStore = new BookStore();

            public static AdminService CreateAdminService()
            {
                return new AdminService
                {
                    _bookReader = _bookStore,
                    _bookWriter = _bookStore
                };
            }

            public static PublicService CreatePublicService()
            {
                return new PublicService
                {
                    _bookReader = _bookStore
                };
            }
        }
    }
}
