using System;
using System.Collections.Generic;

namespace SiddalingeshwaraRiceMill.API.Models;

public partial class LocationDatum
{
    public string Pincode { get; set; } = null!;

    public string? CityName { get; set; }

    public string? StateName { get; set; }

    public string? CountryName { get; set; }
}
