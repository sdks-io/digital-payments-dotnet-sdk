// <copyright file="Datum.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ShellSmartPayAPI.Standard;
using ShellSmartPayAPI.Standard.Utilities;

namespace ShellSmartPayAPI.Standard.Models
{
    /// <summary>
    /// Datum.
    /// </summary>
    public class Datum
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Datum"/> class.
        /// </summary>
        public Datum()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Datum"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="type">type.</param>
        /// <param name="name">name.</param>
        /// <param name="addr">addr.</param>
        /// <param name="lat">lat.</param>
        /// <param name="lon">lon.</param>
        /// <param name="amen">amen.</param>
        /// <param name="fuel">fuel.</param>
        /// <param name="loc">loc.</param>
        /// <param name="mppStationId">mpp_station_id.</param>
        /// <param name="doubleSiteId">double_site_id.</param>
        /// <param name="openingHours">opening_hours.</param>
        /// <param name="telephone">telephone.</param>
        /// <param name="authorisationCode">authorisation_code.</param>
        /// <param name="mpPreauth">mp_preauth.</param>
        public Datum(
            string id = null,
            int? type = null,
            string name = null,
            string addr = null,
            double? lat = null,
            double? lon = null,
            List<int> amen = null,
            List<int> fuel = null,
            Models.Loc loc = null,
            string mppStationId = null,
            string doubleSiteId = null,
            List<Models.OpeningHour> openingHours = null,
            string telephone = null,
            string authorisationCode = null,
            int? mpPreauth = null)
        {
            this.Id = id;
            this.Type = type;
            this.Name = name;
            this.Addr = addr;
            this.Lat = lat;
            this.Lon = lon;
            this.Amen = amen;
            this.Fuel = fuel;
            this.Loc = loc;
            this.MppStationId = mppStationId;
            this.DoubleSiteId = doubleSiteId;
            this.OpeningHours = openingHours;
            this.Telephone = telephone;
            this.AuthorisationCode = authorisationCode;
            this.MpPreauth = mpPreauth;
        }

        /// <summary>
        /// The station’s unique site identifier – this must be ignored
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// All fuel stations are of at least one Type, indicating whether it is Shell-branded or not, and if the
        /// station can be used by trucks. Note that a station can have more than one Type (e.g. Shell retail
        /// sites (Type=0) can also be truck friendly (Type=2)).
        /// Type values are as follows:
        /// *  0 = Shell owned/branded stations that are not also Type=2 or Type=3
        /// *  1 = Partner stations accepting Shell Card
        /// *  2 = Shell owned/branded stations that are truck friendly but not Type=3
        /// *  3 = Shell owned/branded stations that are truck only
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public int? Type { get; set; }

        /// <summary>
        /// The name of the site
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// The side address as a concatenation of address information
        /// </summary>
        [JsonProperty("addr", NullValueHandling = NullValueHandling.Ignore)]
        public string Addr { get; set; }

        /// <summary>
        /// The site’s latitude
        /// </summary>
        [JsonProperty("lat", NullValueHandling = NullValueHandling.Ignore)]
        public double? Lat { get; set; }

        /// <summary>
        /// The site’s longitude
        /// </summary>
        [JsonProperty("lon", NullValueHandling = NullValueHandling.Ignore)]
        public double? Lon { get; set; }

        /// <summary>
        /// An array of amenities available at the station (see above for complete list)
        /// </summary>
        [JsonProperty("amen", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> Amen { get; set; }

        /// <summary>
        /// An array of fuels* available at the station.
        ///  Global Product Group names:
        ///  *  8 = CNG
        ///  *  10 = Premium Gasoline
        ///  *  11 = Premium Diesel
        ///  *  12 = Fuelsave Midgrade Gasoline
        ///  *  13 = Fuelsave Regular Diesel
        ///  *  14 = Midgrade Gasoline
        ///  *  15 = Low Octane gasoline
        ///  *  16 = Regular Diesel
        ///  *  17 = Autogas LPG
        ///  *  18 = Auto/RV Propane
        ///  *  20 = Hydrogen
        ///  *  21 = Kerosene
        ///  *  22 = Super Premium Gasoline
        ///  *  23 = Unleaded Super
        ///  *  24 = Truck Diesel
        ///  *  25 = Super98
        ///  *  26 = GTL
        ///  *  27 = Fuelsave 98
        ///  *  28 = LNG
        ///  *  29 = DieselFit
        ///  *  30 = Shell Recharge
        /// 
        ///  *An external mapping table may need to be maintained if it is required to display true fuel product names (as visible on the site)
        /// </summary>
        [JsonProperty("fuel", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> Fuel { get; set; }

        /// <summary>
        /// Object containing address details/elements
        /// </summary>
        [JsonProperty("loc", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Loc Loc { get; set; }

        /// <summary>
        /// This is the 5-digit Shell Station ID. Leading ‘0’ should be dropped and only last four digits, should be used. E.G. for ‘00123’, only ‘0123’ should be used and for ‘04567’ only ‘4567’ should be used.
        /// </summary>
        [JsonProperty("mpp_station_id", NullValueHandling = NullValueHandling.Ignore)]
        public string MppStationId { get; set; }

        /// <summary>
        /// The Mobile Payment Platform recognises a user being located at a Shell Station if their GPS is within 300m of a Shell station. Some locations will return multiple Shell Stations within a 300 meter radius. This is an issue for Mobile Payments as it needs  to accurately identify the station the Customer is located at to ensure the correct pump is released
        /// In Germany such locations have been identified and each Station has been assigned a unique letter (e.g. A, B, C). These letters are clearly visible at the stations. If a Mobile Payments user is located at such a location, they will need to identify the Station by identifying and specifying the Station’s corresponding letter as part of the refuelling journey.
        /// The double_site_id is used to store the Stations unique letter/ID value. It’s only populated if/when 1 or more stations are within 300m from this station.
        /// </summary>
        [JsonProperty("double_site_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DoubleSiteId { get; set; }

        /// <summary>
        /// An Array of the station’s opening hours. This may have opening and closing times in hours, minutes and the day of the week.
        /// </summary>
        [JsonProperty("opening_hours", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.OpeningHour> OpeningHours { get; set; }

        /// <summary>
        /// Station’s contact telephone number
        /// </summary>
        [JsonProperty("telephone", NullValueHandling = NullValueHandling.Ignore)]
        public string Telephone { get; set; }

        /// <summary>
        /// Station’s authorisation code
        /// </summary>
        [JsonProperty("authorisation_code", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorisationCode { get; set; }

        /// <summary>
        /// Station’s mobile payment preauthorisation value
        /// </summary>
        [JsonProperty("mp_preauth", NullValueHandling = NullValueHandling.Ignore)]
        public int? MpPreauth { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"Datum : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is Datum other &&
                (this.Id == null && other.Id == null ||
                 this.Id?.Equals(other.Id) == true) &&
                (this.Type == null && other.Type == null ||
                 this.Type?.Equals(other.Type) == true) &&
                (this.Name == null && other.Name == null ||
                 this.Name?.Equals(other.Name) == true) &&
                (this.Addr == null && other.Addr == null ||
                 this.Addr?.Equals(other.Addr) == true) &&
                (this.Lat == null && other.Lat == null ||
                 this.Lat?.Equals(other.Lat) == true) &&
                (this.Lon == null && other.Lon == null ||
                 this.Lon?.Equals(other.Lon) == true) &&
                (this.Amen == null && other.Amen == null ||
                 this.Amen?.Equals(other.Amen) == true) &&
                (this.Fuel == null && other.Fuel == null ||
                 this.Fuel?.Equals(other.Fuel) == true) &&
                (this.Loc == null && other.Loc == null ||
                 this.Loc?.Equals(other.Loc) == true) &&
                (this.MppStationId == null && other.MppStationId == null ||
                 this.MppStationId?.Equals(other.MppStationId) == true) &&
                (this.DoubleSiteId == null && other.DoubleSiteId == null ||
                 this.DoubleSiteId?.Equals(other.DoubleSiteId) == true) &&
                (this.OpeningHours == null && other.OpeningHours == null ||
                 this.OpeningHours?.Equals(other.OpeningHours) == true) &&
                (this.Telephone == null && other.Telephone == null ||
                 this.Telephone?.Equals(other.Telephone) == true) &&
                (this.AuthorisationCode == null && other.AuthorisationCode == null ||
                 this.AuthorisationCode?.Equals(other.AuthorisationCode) == true) &&
                (this.MpPreauth == null && other.MpPreauth == null ||
                 this.MpPreauth?.Equals(other.MpPreauth) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {this.Id ?? "null"}");
            toStringOutput.Add($"Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"Name = {this.Name ?? "null"}");
            toStringOutput.Add($"Addr = {this.Addr ?? "null"}");
            toStringOutput.Add($"Lat = {(this.Lat == null ? "null" : this.Lat.ToString())}");
            toStringOutput.Add($"Lon = {(this.Lon == null ? "null" : this.Lon.ToString())}");
            toStringOutput.Add($"Amen = {(this.Amen == null ? "null" : $"[{string.Join(", ", this.Amen)} ]")}");
            toStringOutput.Add($"Fuel = {(this.Fuel == null ? "null" : $"[{string.Join(", ", this.Fuel)} ]")}");
            toStringOutput.Add($"Loc = {(this.Loc == null ? "null" : this.Loc.ToString())}");
            toStringOutput.Add($"MppStationId = {this.MppStationId ?? "null"}");
            toStringOutput.Add($"DoubleSiteId = {this.DoubleSiteId ?? "null"}");
            toStringOutput.Add($"OpeningHours = {(this.OpeningHours == null ? "null" : $"[{string.Join(", ", this.OpeningHours)} ]")}");
            toStringOutput.Add($"Telephone = {this.Telephone ?? "null"}");
            toStringOutput.Add($"AuthorisationCode = {this.AuthorisationCode ?? "null"}");
            toStringOutput.Add($"MpPreauth = {(this.MpPreauth == null ? "null" : this.MpPreauth.ToString())}");
        }
    }
}