using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LexPharm.Models
{
    public enum DrugCategory
    {
        [Description("Heart Disease")]
        Admin = 1,
        [Description("Diabetes")]
        Diabetes,
        [Description("Typhoid")]
        Typhoid,
        [Description("fever")]
        fever,
        [Description("Cancer")]
        Cancer, 
        [Description("Bacteria infection")]
        BacteriaInfection,
        [Description("Pneumonia")]
        Pneumonia,
        [Description("Tuberculosis")]
        Tuberculosis,
        [Description("Headaches")]
        Headaches,
        [Description("Colds and Flu")]
        ColdFlu,
        [Description("Stomach Aches")]
        StomachAches,
        [Description("Malaria")]
        Malaria,
        [Description("smallpox")]
        smallpox,
        [Description("hepatitis")]
        hepatitis,

    }
}
