//namespace PraticalTest.Server.Models
//{
//    public class DataModel
//    {

//        public class Property
//        {
//            public string Value { get; set; }
//            public string Label { get; set; }
//        }

//        public class Data
//        {
//            public string SamplingTime { get; set; }
//            public List<Property> Properties { get; set; }
//        }

//        public class JsonPayload
//        {
//            public int Id { get; set; }
//            public string Name { get; set; }
//            public List<Data> Datas { get; set; }
//        }


//    }
//}


namespace PraticalTest.Server.Models
{
    public class DataModel
    {
        public class Property
        {
            public object Value { get; set; } // Changed to object to handle multiple data types
            public string Label { get; set; }
        }

        public class Data
        {
            public string SamplingTime { get; set; }
            public List<Property> Properties { get; set; }
        }

        public class JsonPayload
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<Data> Datas { get; set; }
        }
    }
}
