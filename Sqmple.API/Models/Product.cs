using SelfApiSourceGenerator.Attributes;


namespace sample.API.Models
{
    [GenerateApi(Version = 1.0)]
    [ExposeEndpoint(Get = true, GetByKey = true, Post = true, Put = true, DeleteByKey = false)]

    public class Product
    {
        [isKeyFieldApi]
        public int id { get; set; }

        [isKeyFieldApi]
        [CreateRequirdeFieldApi]
        public string company { get; set; }


        [UpdateableFieldApi]
        [CreateRequirdeFieldApi]
        public double price { get; set; }


        [UpdateableFieldApi]
        [CreateRequirdeFieldApi]
        public string description { get; set; }


        [NonFieldApi]
        public string Discount { get; set; }



    }
}