namespace Dotnet.Core.Common.Contracts
{
    public static class Routes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version + "/";

        public static class Cities
        {
            public const string Model = Base + "city";
            public const string GetAll = Base + "cities";
            public const string Details = Base + "cities/details";
            public const string GetById = Model + "/{id}";
            public const string Create = Model + "/create";
            public const string Update = Model + "/update/{id}";
            public const string Delete = Model + "/delete/{id}";
            public const string Force = Model + "/delete/{id}/force";
        }
        
        public static class Continentals
        {
            public const string Model = Base + "continental";
            public const string GetAll = Model + "s";
            public const string GetById = Model + "/{id}";
            public const string Create = Model + "/create";
            public const string Update = Model + "/update/{id}";
            public const string Delete = Model + "/delete/{id}";
            public const string Force = Model + "/delete/{id}/force";
        }

        public static class Regions
        {
            public const string Model = Base + "region";
            public const string GetAll = Model + "s";
            public const string GetById = Model + "/{id}";
            public const string Create = Model + "/create";
            public const string Update = Model + "/update/{id}";
            public const string Delete = Model + "/delete/{id}";
            public const string Force = Model + "/delete/{id}/force";
        }

        public static class Countries
        {
            public const string Model = Base + "country";
            public const string GetAll = Base + "countries";
            public const string GetById = Model + "/{id}";
            public const string Create = Model + "/create";
            public const string Update = Model + "/update/{id}";
            public const string Delete = Model + "/delete/{id}";
            public const string Force = Model + "/delete/{id}/force";
        }
    }
}