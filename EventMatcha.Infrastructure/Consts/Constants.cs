namespace EventMatcha.Infrastructure.Consts
{
    public static class Constants
    {
        public static class Collections
        {
             public const string Foto = "Fotos";
             public const string Testimonial = "Testimonials";
             public const string Faqs = "Faqs";
        }

        public static class QueryParams
        {
            public const string CreatedOn = "createdOn";
            public const string GreaterThan = "$gt";
            public const string LessThan = "$lt";
            public const string IsDeleted = "isDeleted";
            public const string Matches = "$eq";
        }
    }
}
