using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Dotnet.Core.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "continentals",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_continentals", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "regions",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    continental_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_regions", x => x.id);
                    table.ForeignKey(
                        name: "fk_regions_continentals_continental_id",
                        column: x => x.continental_id,
                        principalSchema: "public",
                        principalTable: "continentals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    region_id = table.Column<int>(nullable: false),
                    alpha_2_code = table.Column<string>(type: "varchar", maxLength: 2, nullable: false),
                    alpha_3_code = table.Column<string>(type: "varchar", maxLength: 3, nullable: false),
                    un_code = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_countries", x => x.id);
                    table.ForeignKey(
                        name: "fk_countries_regions_region_id",
                        column: x => x.region_id,
                        principalSchema: "public",
                        principalTable: "regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    country_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cities", x => x.id);
                    table.ForeignKey(
                        name: "fk_cities_countries_country_id",
                        column: x => x.country_id,
                        principalSchema: "public",
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "continentals",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Africa" },
                    { 2, "Americas" },
                    { 3, "Antarctica" },
                    { 4, "Asia" },
                    { 5, "Europe" },
                    { 6, "Oceania" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "regions",
                columns: new[] { "id", "continental_id", "name" },
                values: new object[,]
                {
                    { 1, 1, "Central Africa" },
                    { 22, 5, "Southern Europe" },
                    { 21, 5, "South West Europe" },
                    { 20, 5, "South East Europe" },
                    { 19, 5, "Northern Europe" },
                    { 18, 5, "Eastern Europe" },
                    { 17, 5, "Central Europe" },
                    { 16, 4, "South West Asia" },
                    { 15, 4, "South Asia" },
                    { 14, 4, "Northern Asia" },
                    { 13, 4, "East Asia" },
                    { 12, 4, "Central Asia" },
                    { 11, 3, "Atlantic Ocean" },
                    { 10, 2, "West Indies" },
                    { 9, 2, "South America" },
                    { 8, 2, "North America" },
                    { 7, 2, "Central America" },
                    { 6, 1, "Western Africa" },
                    { 5, 1, "Southern Africa" },
                    { 4, 1, "Northern Africa" },
                    { 3, 1, "Indian Ocean" },
                    { 2, 1, "Eastern Africa" },
                    { 23, 5, "Western Europe" },
                    { 24, 6, "Pacific" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "countries",
                columns: new[] { "id", "alpha_2_code", "alpha_3_code", "name", "region_id", "un_code" },
                values: new object[,]
                {
                    { 108, "BI", "BDI", "Burundi", 1, "108" },
                    { 48, "BH", "BHR", "Bahrain", 16, "048" },
                    { 196, "CY", "CYP", "Cyprus", 16, "196" },
                    { 268, "GE", "GEO", "Georgia", 16, "268" },
                    { 376, "IL", "ISR", "Israel", 16, "376" },
                    { 364, "IR", "IRN", "Iran, Islamic Republic of", 16, "364" },
                    { 368, "IQ", "IRQ", "Iraq", 16, "368" },
                    { 400, "JO", "JOR", "Jordan", 16, "400" },
                    { 414, "KW", "KWT", "Kuwait", 16, "414" },
                    { 422, "LB", "LBN", "Lebanon", 16, "422" },
                    { 512, "OM", "OMN", "Oman", 16, "512" },
                    { 634, "QA", "QAT", "Qatar", 16, "634" },
                    { 682, "SA", "SAU", "Saudi Arabia", 16, "682" },
                    { 760, "SY", "SYR", "Syrian Arab Republic (Syria)", 16, "760" },
                    { 792, "TR", "TUR", "Turkey", 16, "792" },
                    { 887, "YE", "YEM", "Yemen", 16, "887" },
                    { 40, "AT", "AUT", "Austria", 17, "040" },
                    { 203, "CZ", "CZE", "Czech Republic", 17, "203" },
                    { 348, "HU", "HUN", "Hungary", 17, "348" },
                    { 703, "SK", "SVK", "Slovakia", 17, "703" },
                    { 438, "LI", "LIE", "Liechtenstein", 17, "438" },
                    { 756, "CH", "CHE", "Switzerland", 17, "756" },
                    { 112, "BY", "BLR", "Belarus", 18, "112" },
                    { 233, "EE", "EST", "Estonia", 18, "233" },
                    { 428, "LV", "LVA", "Latvia", 18, "428" },
                    { 440, "LT", "LTU", "Lithuania", 18, "440" },
                    { 51, "AM", "ARM", "Armenia", 16, "051" },
                    { 498, "MD", "MDA", "Moldova, Republic of", 18, "498" },
                    { 31, "AZ", "AZE", "Azerbaijan", 16, "031" },
                    { 704, "VN", "VNM", "Vietnam", 15, "704" },
                    { 446, "MO", "MAC", "Macao, SAR China", 13, "446" },
                    { 158, "TW", "TWN", "Taiwan, Republic of China", 13, "158" },
                    { 496, "MN", "MNG", "Mongolia", 14, "496" },
                    { 643, "RU", "RUS", "Russian Federation", 14, "643" },
                    { 4, "AF", "AFG", "Afghanistan", 15, "004" },
                    { 50, "BD", "BGD", "Bangladesh", 15, "050" },
                    { 64, "BT", "BTN", "Bhutan", 15, "064" },
                    { 144, "LK", "LKA", "Sri Lanka", 15, "144" },
                    { 356, "IN", "IND", "India", 15, "356" },
                    { 86, "IO", "IOT", "British Indian Ocean Territory", 15, "086" },
                    { 462, "MV", "MDV", "Maldives", 15, "462" },
                    { 524, "NP", "NPL", "Nepal", 15, "524" },
                    { 586, "PK", "PAK", "Pakistan", 15, "586" },
                    { 104, "MM", "MMR", "Myanmar", 15, "104" },
                    { 96, "BN", "BRN", "Brunei Darussalam", 15, "096" },
                    { 116, "KH", "KHM", "Cambodia", 15, "116" },
                    { 166, "CC", "CCK", "Cocos (Keeling) Islands", 15, "166" },
                    { 360, "ID", "IDN", "Indonesia", 15, "360" },
                    { 162, "CX", "CXR", "Christmas Island", 15, "162" },
                    { 418, "LA", "LAO", "Lao PDR", 15, "418" },
                    { 458, "MY", "MYS", "Malaysia", 15, "458" },
                    { 608, "PH", "PHL", "Philippines", 15, "608" },
                    { 702, "SG", "SGP", "Singapore", 15, "702" },
                    { 764, "TH", "THA", "Thailand", 15, "764" },
                    { 626, "TL", "TLS", "Timor-Leste", 15, "626" },
                    { 784, "AE", "ARE", "United Arab Emirates", 16, "784" },
                    { 616, "PL", "POL", "Poland", 18, "616" },
                    { 804, "UA", "UKR", "Ukraine", 18, "804" },
                    { 248, "AX", "ALA", "Åland Islands", 19, "248" },
                    { 833, "IM", "IMN", "Isle of Man", 23, "833" },
                    { 832, "JE", "JEY", "Jersey", 23, "832" },
                    { 442, "LU", "LUX", "Luxembourg", 23, "442" },
                    { 492, "MC", "MCO", "Monaco", 23, "492" },
                    { 528, "NL", "NLD", "Netherlands", 23, "528" },
                    { 36, "AU", "AUS", "Australia", 24, "036" },
                    { 90, "SB", "SLB", "Solomon Islands", 24, "090" },
                    { 184, "CK", "COK", "Cook Islands", 24, "184" },
                    { 242, "FJ", "FJI", "Fiji", 24, "242" },
                    { 583, "FM", "FSM", "Micronesia, Federated States of", 24, "583" },
                    { 258, "PF", "PYF", "French Polynesia", 24, "258" },
                    { 296, "KI", "KIR", "Kiribati", 24, "296" },
                    { 540, "NC", "NCL", "New Caledonia", 24, "540" },
                    { 570, "NU", "NIU", "Niue", 24, "570" },
                    { 574, "NF", "NFK", "Norfolk Island", 24, "574" },
                    { 548, "VU", "VUT", "Vanuatu", 24, "548" },
                    { 520, "NR", "NRU", "Nauru", 24, "520" },
                    { 554, "NZ", "NZL", "New Zealand", 24, "554" },
                    { 612, "PN", "PCN", "Pitcairn Islands", 24, "612" },
                    { 598, "PG", "PNG", "Papua New Guinea", 24, "598" },
                    { 585, "PW", "PLW", "Palau", 24, "585" },
                    { 584, "MH", "MHL", "Marshall Islands", 24, "584" },
                    { 772, "TK", "TKL", "Tokelau", 24, "772" },
                    { 776, "TO", "TON", "Tonga", 24, "776" },
                    { 798, "TV", "TUV", "Tuvalu", 24, "798" },
                    { 276, "DE", "DEU", "Germany", 23, "276" },
                    { 826, "GB", "GBR", "United Kingdom", 23, "826" },
                    { 250, "FR", "FRA", "France", 23, "250" },
                    { 372, "IE", "IRL", "Ireland", 23, "372" },
                    { 208, "DK", "DNK", "Denmark", 19, "208" },
                    { 246, "FI", "FIN", "Finland", 19, "246" },
                    { 234, "FO", "FRO", "Faroe Islands", 19, "234" },
                    { 352, "IS", "ISL", "Iceland", 19, "352" },
                    { 744, "SJ", "SJM", "Svalbard and Jan Mayen Islands", 19, "744" },
                    { 578, "NO", "NOR", "Norway", 19, "578" },
                    { 752, "SE", "SWE", "Sweden", 19, "752" },
                    { 8, "AL", "ALB", "Albania", 20, "008" },
                    { 70, "BA", "BIH", "Bosnia and Herzegovina", 20, "070" },
                    { 100, "BG", "BGR", "Bulgaria", 20, "100" },
                    { 300, "GR", "GRC", "Greece", 20, "300" },
                    { 191, "HR", "HRV", "Croatia", 20, "191" },
                    { 410, "KR", "KOR", "Korea, South", 13, "410" },
                    { 383, "XK", "XKX", "Kosovo", 20, "383" },
                    { 807, "MK", "MKD", "Macedonia, Republic of", 20, "807" },
                    { 688, "RS", "SRB", "Serbia", 20, "688" },
                    { 642, "RO", "ROU", "Romania", 20, "642" },
                    { 705, "SI", "SVN", "Slovenia", 20, "705" },
                    { 20, "AD", "AND", "Andorra", 21, "020" },
                    { 292, "GI", "GIB", "Gibraltar", 21, "292" },
                    { 620, "PT", "PRT", "Portugal", 21, "620" },
                    { 724, "ES", "ESP", "Spain", 21, "724" },
                    { 380, "IT", "ITA", "Italy", 22, "380" },
                    { 470, "MT", "MLT", "Malta", 22, "470" },
                    { 674, "SM", "SMR", "San Marino", 22, "674" },
                    { 56, "BE", "BEL", "Belgium", 23, "056" },
                    { 499, "ME", "MNE", "Montenegro", 20, "499" },
                    { 876, "WF", "WLF", "Wallis and Futuna Islands", 24, "876" },
                    { 408, "KP", "PRK", "Korea, North", 13, "408" },
                    { 344, "HK", "HKG", "Hong Kong, SAR China", 13, "344" },
                    { 454, "MW", "MWI", "Malawi", 5, "454" },
                    { 508, "MZ", "MOZ", "Mozambique", 5, "508" },
                    { 710, "ZA", "ZAF", "South Africa", 5, "710" },
                    { 516, "NA", "NAM", "Namibia", 5, "516" },
                    { 748, "SZ", "SWZ", "Swaziland", 5, "748" },
                    { 894, "ZM", "ZMB", "Zambia", 5, "894" },
                    { 716, "ZW", "ZWE", "Zimbabwe", 5, "716" },
                    { 204, "BJ", "BEN", "Benin", 6, "204" },
                    { 120, "CM", "CMR", "Cameroon", 6, "120" },
                    { 132, "CV", "CPV", "Cape Verde", 6, "132" },
                    { 226, "GQ", "GNQ", "Equatorial Guinea", 6, "226" },
                    { 270, "GM", "GMB", "Gambia, The", 6, "270" },
                    { 266, "GA", "GAB", "Gabon", 6, "266" },
                    { 288, "GH", "GHA", "Ghana", 6, "288" },
                    { 324, "GN", "GIN", "Guinea", 6, "324" },
                    { 384, "CI", "CIV", "Cote d'Ivoire", 6, "384" },
                    { 430, "LR", "LBR", "Liberia", 6, "430" },
                    { 466, "ML", "MLI", "Mali", 6, "466" },
                    { 478, "MR", "MRT", "Mauritania", 6, "478" },
                    { 562, "NE", "NER", "Niger", 6, "562" },
                    { 566, "NG", "NGA", "Nigeria", 6, "566" },
                    { 624, "GW", "GNB", "Guinea-Bissau", 6, "624" },
                    { 686, "SN", "SEN", "Senegal", 6, "686" },
                    { 694, "SL", "SLE", "Sierra Leone", 6, "694" },
                    { 768, "TG", "TGO", "Togo", 6, "768" },
                    { 426, "LS", "LSO", "Lesotho", 5, "426" },
                    { 678, "ST", "STP", "Sao Tome and Principe", 6, "678" },
                    { 72, "BW", "BWA", "Botswana", 5, "072" },
                    { 732, "EH", "ESH", "Western Sahara", 4, "732" },
                    { 148, "TD", "TCD", "Chad", 1, "148" },
                    { 178, "CG", "COG", "Congo, Republic of the", 1, "178" },
                    { 180, "CD", "COD", "Congo, Democratic Republic of the", 1, "180" },
                    { 140, "CF", "CAF", "Central African Republic", 1, "140" },
                    { 646, "RW", "RWA", "Rwanda", 1, "646" },
                    { 262, "DJ", "DJI", "Djibouti", 2, "262" },
                    { 232, "ER", "ERI", "Eritrea", 2, "232" },
                    { 231, "ET", "ETH", "Ethiopia", 2, "231" },
                    { 404, "KE", "KEN", "Kenya", 2, "404" },
                    { 706, "SO", "SOM", "Somalia", 2, "706" },
                    { 728, "SS", "SSD", "South Sudan", 2, "728" },
                    { 834, "TZ", "TZA", "Tanzania, United Republic of", 2, "834" },
                    { 800, "UG", "UGA", "Uganda", 2, "800" },
                    { 174, "KM", "COM", "Comoros", 3, "174" },
                    { 450, "MG", "MDG", "Madagascar", 3, "450" },
                    { 175, "YT", "MYT", "Mayotte", 3, "175" },
                    { 480, "MU", "MUS", "Mauritius", 3, "480" },
                    { 638, "RE", "REU", "Réunion", 3, "638" },
                    { 690, "SC", "SYC", "Seychelles", 3, "690" },
                    { 12, "DZ", "DZA", "Algeria", 4, "012" },
                    { 818, "EG", "EGY", "Egypt", 4, "818" },
                    { 434, "LY", "LBY", "Libya", 4, "434" },
                    { 504, "MA", "MAR", "Morocco", 4, "504" },
                    { 736, "SD", "SDN", "Sudan", 4, "736" },
                    { 788, "TN", "TUN", "Tunisia", 4, "788" },
                    { 24, "AO", "AGO", "Angola", 5, "024" },
                    { 854, "BF", "BFA", "Burkina Faso", 6, "854" },
                    { 84, "BZ", "BLZ", "Belize", 7, "084" },
                    { 188, "CR", "CRI", "Costa Rica", 7, "188" },
                    { 136, "KY", "CYM", "Cayman Islands", 10, "136" },
                    { 192, "CU", "CUB", "Cuba", 10, "192" },
                    { 212, "DM", "DMA", "Dominica", 10, "212" },
                    { 214, "DO", "DOM", "Dominican Republic", 10, "214" },
                    { 308, "GD", "GRD", "Grenada", 10, "308" },
                    { 312, "GP", "GLP", "Guadeloupe", 10, "312" },
                    { 332, "HT", "HTI", "Haiti", 10, "332" },
                    { 388, "JM", "JAM", "Jamaica", 10, "388" },
                    { 474, "MQ", "MTQ", "Martinique", 10, "474" },
                    { 500, "MS", "MSR", "Montserrat", 10, "500" },
                    { 663, "MF", "MAF", "Saint-Martin (French part)", 10, "663" },
                    { 659, "KN", "KNA", "Saint Kitts and Nevis", 10, "659" },
                    { 662, "LC", "LCA", "Saint Lucia", 10, "662" },
                    { 780, "TT", "TTO", "Trinidad and Tobago", 10, "780" },
                    { 796, "TC", "TCA", "Turks and Caicos Islands", 10, "796" },
                    { 670, "VC", "VCT", "Saint Vincent and the Grenadines", 10, "670" },
                    { 92, "VG", "VGB", "British Virgin Islands", 10, "092" },
                    { 654, "SH", "SHN", "Saint Helena", 11, "654" },
                    { 239, "GS", "SGS", "South Georgia and the South Sandwich Islands", 11, "239" },
                    { 417, "KG", "KGZ", "Kyrgyzstan", 12, "417" },
                    { 398, "KZ", "KAZ", "Kazakhstan", 12, "398" },
                    { 762, "TJ", "TJK", "Tajikistan", 12, "762" },
                    { 795, "TM", "TKM", "Turkmenistan", 12, "795" },
                    { 860, "UZ", "UZB", "Uzbekistan", 12, "860" },
                    { 156, "CN", "CHN", "China", 13, "156" },
                    { 44, "BS", "BHS", "Bahamas, The", 10, "044" },
                    { 60, "BM", "BMU", "Bermuda", 10, "060" },
                    { 52, "BB", "BRB", "Barbados", 10, "052" },
                    { 660, "AI", "AIA", "Anguilla", 10, "660" },
                    { 222, "SV", "SLV", "El Salvador", 7, "222" },
                    { 320, "GT", "GTM", "Guatemala", 7, "320" },
                    { 340, "HN", "HND", "Honduras", 7, "340" },
                    { 484, "MX", "MEX", "Mexico", 7, "484" },
                    { 558, "NI", "NIC", "Nicaragua", 7, "558" },
                    { 591, "PA", "PAN", "Panama", 7, "591" },
                    { 124, "CA", "CAN", "Canada", 8, "124" },
                    { 304, "GL", "GRL", "Greenland", 8, "304" },
                    { 666, "PM", "SPM", "Saint Pierre and Miquelon", 8, "666" },
                    { 840, "US", "USA", "United States of America", 8, "840" },
                    { 32, "AR", "ARG", "Argentina", 9, "032" },
                    { 68, "BO", "BOL", "Bolivia", 9, "068" },
                    { 392, "JP", "JPN", "Japan", 13, "392" },
                    { 76, "BR", "BRA", "Brazil", 9, "076" },
                    { 170, "CO", "COL", "Colombia", 9, "170" },
                    { 218, "EC", "ECU", "Ecuador", 9, "218" },
                    { 254, "GF", "GUF", "French Guiana", 9, "254" },
                    { 238, "FK", "FLK", "Falkland Islands (Islas Malvinas)", 9, "238" },
                    { 328, "GY", "GUY", "Guyana", 9, "328" },
                    { 740, "SR", "SUR", "Suriname", 9, "740" },
                    { 600, "PY", "PRY", "Paraguay", 9, "600" },
                    { 604, "PE", "PER", "Peru", 9, "604" },
                    { 858, "UY", "URY", "Uruguay", 9, "858" },
                    { 862, "VE", "VEN", "Venezuela (Bolivarian Republic)", 9, "862" },
                    { 533, "AW", "ABW", "Aruba", 10, "533" },
                    { 28, "AG", "ATG", "Antigua and Barbuda", 10, "028" },
                    { 152, "CL", "CHL", "Chile", 9, "152" },
                    { 882, "WS", "WSM", "Samoa", 24, "882" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "cities",
                columns: new[] { "id", "country_id", "name" },
                values: new object[,]
                {
                    { 82, 840, "Alabama" },
                    { 46, 792, "Kastamonu" },
                    { 45, 792, "Kars" },
                    { 44, 792, "Karaman" },
                    { 43, 792, "Karabük" },
                    { 42, 792, "Kahramanmaraş" },
                    { 41, 792, "İzmir" },
                    { 40, 792, "İstanbul" },
                    { 39, 792, "Isparta" },
                    { 38, 792, "Iğdır" },
                    { 37, 792, "Hatay" },
                    { 36, 792, "Hakkâri" },
                    { 35, 792, "Gümüşhane" },
                    { 34, 792, "Giresun" },
                    { 33, 792, "Gaziantep" },
                    { 32, 792, "Eskişehir" },
                    { 31, 792, "Erzurum" },
                    { 30, 792, "Erzincan" },
                    { 29, 792, "Elazığ" },
                    { 28, 792, "Edirne" },
                    { 27, 792, "Düzce" },
                    { 26, 792, "Diyarbakır" },
                    { 25, 792, "Denizli" },
                    { 24, 792, "Çorum" },
                    { 23, 792, "Çankırı" },
                    { 22, 792, "Çanakkale" },
                    { 21, 792, "Bursa" },
                    { 20, 792, "Burdur" },
                    { 19, 792, "Bolu" },
                    { 18, 792, "Bitlis" },
                    { 47, 792, "Kayseri" },
                    { 17, 792, "Bingöl" },
                    { 48, 792, "Kilis" },
                    { 50, 792, "Kırklareli" },
                    { 79, 792, "Yalova" },
                    { 78, 792, "Van" },
                    { 77, 792, "Uşak" },
                    { 76, 792, "Tunceli" },
                    { 75, 792, "Trabzon" },
                    { 74, 792, "Tokat" },
                    { 73, 792, "Tekirdağ" },
                    { 72, 792, "Sivas" },
                    { 71, 792, "Şırnak" },
                    { 70, 792, "Sinop" },
                    { 69, 792, "Siirt" },
                    { 68, 792, "Şanlıurfa" },
                    { 67, 792, "Samsun" },
                    { 66, 792, "Sakarya" },
                    { 65, 792, "Rize" },
                    { 64, 792, "Osmaniye" },
                    { 63, 792, "Ordu" },
                    { 62, 792, "Niğde" },
                    { 61, 792, "Nevşehir" },
                    { 60, 792, "Muş" },
                    { 59, 792, "Muğla" },
                    { 58, 792, "Mersin" },
                    { 57, 792, "Mardin" },
                    { 56, 792, "Manisa" },
                    { 55, 792, "Malatya" },
                    { 54, 792, "Kütahya" },
                    { 53, 792, "Konya" },
                    { 52, 792, "Kocaeli" },
                    { 51, 792, "Kırşehir" },
                    { 49, 792, "Kırıkkale" },
                    { 16, 792, "Bilecik" },
                    { 15, 792, "Bayburt" },
                    { 14, 792, "Batman" },
                    { 111, 840, "New Jersey" },
                    { 110, 840, "New Hampshire" },
                    { 109, 840, "Nevada" },
                    { 108, 840, "Nebraska" },
                    { 107, 840, "Montana" },
                    { 106, 840, "Missouri" },
                    { 105, 840, "Mississippi" },
                    { 104, 840, "Minnesota" },
                    { 103, 840, "Michigan" },
                    { 102, 840, "Massachusetts" },
                    { 101, 840, "Maryland" },
                    { 100, 840, "Maine" },
                    { 99, 840, "Louisiana" },
                    { 98, 840, "Kentucky" },
                    { 97, 840, "Kansas" },
                    { 96, 840, "Iowa" },
                    { 95, 840, "Indiana" },
                    { 94, 840, "Illinois" },
                    { 93, 840, "Idaho" },
                    { 92, 840, "Hawaii" },
                    { 91, 840, "Georgia" },
                    { 90, 840, "Florida" },
                    { 89, 840, "Delaware" },
                    { 88, 840, "Connecticut" },
                    { 87, 840, "Colorado" },
                    { 86, 840, "California" },
                    { 85, 840, "Arkansas" },
                    { 84, 840, "Arizona" },
                    { 83, 840, "Alaska" },
                    { 112, 840, "New Mexico" },
                    { 113, 840, "New York" },
                    { 114, 840, "North Carolina" },
                    { 115, 840, "North Dakota" },
                    { 13, 792, "Bartın" },
                    { 12, 792, "Balıkesir" },
                    { 11, 792, "Aydın" },
                    { 10, 792, "Artvin" },
                    { 9, 792, "Ardahan" },
                    { 8, 792, "Antalya" },
                    { 7, 792, "Ankara" },
                    { 6, 792, "Amasya" },
                    { 5, 792, "Aksaray" },
                    { 4, 792, "Ağrı" },
                    { 3, 792, "Afyonkarahisar" },
                    { 2, 792, "Adıyaman" },
                    { 1, 792, "Adana" },
                    { 132, 840, "Wyoming" },
                    { 80, 792, "Yozgat" },
                    { 131, 840, "Wisconsin" },
                    { 129, 840, "Washington, D.C." },
                    { 128, 840, "Washington" },
                    { 127, 840, "Virginia" },
                    { 126, 840, "Vermont" },
                    { 125, 840, "Utah" },
                    { 124, 840, "Texas" },
                    { 123, 840, "Tennessee" },
                    { 122, 840, "South Dakota" },
                    { 121, 840, "South Carolina" },
                    { 120, 840, "Rhode Island" },
                    { 119, 840, "Pennsylvania" },
                    { 118, 840, "Oregon" },
                    { 117, 840, "Oklahoma" },
                    { 116, 840, "Ohio" },
                    { 130, 840, "West Virginia" },
                    { 81, 792, "Zonguldak" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_cities_country_id",
                schema: "public",
                table: "cities",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_cities_id",
                schema: "public",
                table: "cities",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_cities_name",
                schema: "public",
                table: "cities",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_continentals_id",
                schema: "public",
                table: "continentals",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_continentals_name",
                schema: "public",
                table: "continentals",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_countries_id",
                schema: "public",
                table: "countries",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_countries_name",
                schema: "public",
                table: "countries",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_countries_region_id",
                schema: "public",
                table: "countries",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "ix_regions_continental_id",
                schema: "public",
                table: "regions",
                column: "continental_id");

            migrationBuilder.CreateIndex(
                name: "IX_regions_id",
                schema: "public",
                table: "regions",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_regions_name",
                schema: "public",
                table: "regions",
                column: "name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cities",
                schema: "public");

            migrationBuilder.DropTable(
                name: "countries",
                schema: "public");

            migrationBuilder.DropTable(
                name: "regions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "continentals",
                schema: "public");
        }
    }
}
