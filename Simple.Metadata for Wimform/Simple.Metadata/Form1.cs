using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple.Metadata
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var type = typeof(Employee);
            var metadataType = typeof(Employee.EmployeeMetadata);
            TypeDescriptor.AddProviderTransparent(
                new AssociatedMetadataTypeTypeDescriptionProvider(type, metadataType), type);

            this.dataGridView1.DataSource = new List<Employee>
            {
                new Employee {Id = 1, UserId = "yao", Password = "1234"}
            };

            GetDataAnnotation1<Employee>();
        }

        public void GetDataAnnotation<T>()
        {
            var type = typeof(T);

            var properties = new AssociatedMetadataTypeTypeDescriptionProvider(type).
                GetTypeDescriptor(type).
                GetProperties();

            foreach (PropertyDescriptor property in properties)
            {
                var name = property.Name;
                var required = property.Attributes.OfType<RequiredAttribute>().FirstOrDefault();
                var displayName = property.Attributes.OfType<DisplayNameAttribute>().FirstOrDefault();
                var stringLength = property.Attributes.OfType<StringLengthAttribute>().FirstOrDefault();

                Console.WriteLine("Property Name :{0}", name);
                Console.WriteLine("required :{0}", required);
                Console.WriteLine("displayName :{0}", (displayName != null) ? displayName.DisplayName : null);
                Console.WriteLine("stringLength Max:{0}", (stringLength != null) ? (int?)stringLength.MaximumLength : null);
            }
        }

        public void GetDataAnnotation1<T>()
        {
            var type = typeof(T);

            var id = type.GetProperty("Id");
            var aa = id.GetCustomAttribute<DisplayNameAttribute>();
        }
    }
}