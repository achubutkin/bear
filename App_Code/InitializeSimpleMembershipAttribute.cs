using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using WebMatrix.WebData;
using MvcApplication6.Models;

namespace Bear
{
    public static class InitializeSimpleMembership
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public static void Init()
        {
            // Обеспечение однократной инициализации ASP.NET Simple Membership при каждом запуске приложения
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<UsersContext>(null);

                try
                {
                    using (var context = new UsersContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Создание базы данных SimpleMembership без схемы миграции Entity Framework
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();

                            /*
                                Обновление от 13.01.2017 chubutkin.a (нач.)
                                Изменить поле "Email" на "UserName" (!)
                                Обновление (кон.)
                            */
                        }
                    }

                    WebSecurity.InitializeDatabaseConnection("StarterSite", "UserProfile", "UserId", "Email", autoCreateTables: true);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Не удалось инициализировать базу данных ASP.NET Simple Membership. Чтобы получить дополнительные сведения, перейдите по адресу: http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}
