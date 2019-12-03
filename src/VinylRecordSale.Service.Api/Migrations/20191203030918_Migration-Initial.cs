using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VinylRecordSale.Service.Api.Migrations
{
    public partial class MigrationInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "VinylRecordSale");

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "VinylRecordSale",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "ConfigCashbacks",
                schema: "VinylRecordSale",
                columns: table => new
                {
                    MusicGenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PercentageSunday = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m),
                    PercentageMonday = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m),
                    PercentageTuesday = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m),
                    PercentageWednesday = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m),
                    PercentageThursday = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m),
                    PercentageFriday = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m),
                    PercentageSaturday = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigCashbacks", x => x.MusicGenreId);
                });

            migrationBuilder.CreateTable(
                name: "MusicGenres",
                schema: "VinylRecordSale",
                columns: table => new
                {
                    MusicGenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicGenres", x => x.MusicGenreId);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                schema: "VinylRecordSale",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    TotalValue = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CashbackTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_Sales_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "VinylRecordSale",
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VinylDiscs",
                schema: "VinylRecordSale",
                columns: table => new
                {
                    VinylDiscId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MusicGenreId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VinylDiscs", x => x.VinylDiscId);
                    table.ForeignKey(
                        name: "FK_VinylDiscs_MusicGenres_MusicGenreId",
                        column: x => x.MusicGenreId,
                        principalSchema: "VinylRecordSale",
                        principalTable: "MusicGenres",
                        principalColumn: "MusicGenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemSales",
                schema: "VinylRecordSale",
                columns: table => new
                {
                    ItemSaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    VinylDiscId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Cashback = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSales", x => x.ItemSaleId);
                    table.ForeignKey(
                        name: "FK_ItemSales_Sales_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "VinylRecordSale",
                        principalTable: "Sales",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemSales_VinylDiscs_VinylDiscId",
                        column: x => x.VinylDiscId,
                        principalSchema: "VinylRecordSale",
                        principalTable: "VinylDiscs",
                        principalColumn: "VinylDiscId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "VinylRecordSale",
                table: "Clients",
                columns: new[] { "ClientId", "Email", "FullName" },
                values: new object[,]
                {
                    { 1, "ricardobarros_Pereira@live.com", "Ricardo Barros" },
                    { 10, "brenomartins42@yahoo.com", "Breno Martins" },
                    { 8, "suelensilva55@live.com", "Suélen Silva" },
                    { 7, "alessandrareis16@gmail.com", "Alessandra Reis" },
                    { 6, "eduardobraga.Reis@yahoo.com", "Eduardo Braga" },
                    { 9, "ceciliacarvalho.Xavier97@gmail.com", "Cecília Carvalho" },
                    { 4, "merciaoliveira_Melo@yahoo.com", "Mércia Oliveira" },
                    { 3, "estherbraga.Saraiva64@hotmail.com", "Esther Braga" },
                    { 2, "yurimoraes.Batista23@bol.com.br", "Yuri Moraes" },
                    { 5, "marcelobatista_Moraes45@yahoo.com", "Marcelo Batista" }
                });

            migrationBuilder.InsertData(
                schema: "VinylRecordSale",
                table: "ConfigCashbacks",
                columns: new[] { "MusicGenreId", "PercentageFriday", "PercentageMonday", "PercentageSaturday", "PercentageSunday", "PercentageThursday", "PercentageTuesday", "PercentageWednesday" },
                values: new object[,]
                {
                    { 1, 15m, 7m, 20m, 25m, 10m, 6m, 2m },
                    { 2, 25m, 5m, 30m, 30m, 20m, 10m, 15m },
                    { 3, 18m, 3m, 25m, 35m, 13m, 5m, 8m },
                    { 4, 20m, 10m, 40m, 40m, 15m, 15m, 15m }
                });

            migrationBuilder.InsertData(
                schema: "VinylRecordSale",
                table: "MusicGenres",
                columns: new[] { "MusicGenreId", "Description" },
                values: new object[,]
                {
                    { 3, "Classic" },
                    { 1, "Pop" },
                    { 2, "Mpb" },
                    { 4, "Rock" }
                });

            migrationBuilder.InsertData(
                schema: "VinylRecordSale",
                table: "VinylDiscs",
                columns: new[] { "VinylDiscId", "MusicGenreId", "Name", "Value" },
                values: new object[,]
                {
                    { 1, 1, "Still Got Time", 50.63m },
                    { 128, 3, "The 50 Greatest Pieces of Classical Music", 25.08m },
                    { 129, 3, "John Williams Plays Bach", 51.14m },
                    { 130, 3, "Verdi: Requiem", 45.75m },
                    { 131, 3, "Stravinsky: The Firebird / The Rite of Spring", 12.46m },
                    { 132, 3, "The Grand Budapest Hotel (Original Soundtrack)", 79.25m },
                    { 133, 3, "The Mission: Music From The Motion Picture", 81.96m },
                    { 134, 3, "Maurizio Pollini - Schumann Complete Recordings", 96.10m },
                    { 135, 3, "The Wind in High Places", 85.32m },
                    { 136, 3, "Adams: Absolute Jest & Grand Pianola Music", 92.78m },
                    { 137, 3, "Yellow Lounge Vol.3", 51.83m },
                    { 138, 3, "Handel: Water Music", 73.39m },
                    { 139, 3, "Tchaikovsky: Overture \"1812\"; Marche slave / Borodin: In the Steppes; Polovtsian Dances / Rimsky-Korsakov: Russian Easter; Capriccio", 89.26m },
                    { 140, 3, "The Complete Landings", 28.58m },
                    { 141, 3, "Inception (Music From The Motion Picture)", 34.78m },
                    { 142, 3, "Bach: Cello Suites Nos. 1, 5 & 6", 94.50m },
                    { 143, 3, "The Twilight Saga: Breaking Dawn - Part 2 (Original Motion Picture Soundtrack)", 67.66m },
                    { 144, 3, "Brahms & Stravinsky: Violin Concertos", 24.04m },
                    { 145, 3, "Adams: Harmonielehre - Short Ride in a Fast Machine", 71.15m },
                    { 146, 3, "AVATAR Music From The Motion Picture Music Composed and Conducted by James Horner", 50.47m },
                    { 147, 3, "Sinkovsky Plays and Sings Vivaldi", 82.02m },
                    { 148, 3, "Hero - Music from the Original Soundtrack", 46.24m },
                    { 127, 3, "Private Peaceful (Original Motion Picture Soundtrack)", 73.43m },
                    { 149, 3, "Time Curve: Music for Piano by Philip Glass and William Duckworth", 89.62m },
                    { 126, 3, "Wartime Consolations", 85.03m },
                    { 124, 3, "Lefanu: Catena / String Quartet No. 2 / Clarinet Concertino", 65.12m },
                    { 103, 3, "The Essential Itzhak Perlman", 42.61m },
                    { 104, 3, "Extreme Classics", 30.15m },
                    { 105, 3, "Mozart - Piano Concertos", 66.07m },
                    { 106, 3, "Green - Mélodies françaises", 30.80m },
                    { 107, 3, "Legends Of The Fall Original Motion Picture Soundtrack", 48.75m },
                    { 108, 3, "The Leftovers: Season 1 (Music from the HBO Series)", 56.62m },
                    { 109, 3, "Tenore", 33.12m },
                    { 110, 3, "Gregorian Chant", 39.36m },
                    { 111, 3, "Handel: Messiah", 55.68m },
                    { 112, 3, "Alexandre Tharaud. \"Voyage en France\"", 51.81m },
                    { 113, 3, "Monteverdi: Vespers of 1610", 96.40m },
                    { 114, 3, "Beethoven: The Symphonies", 68.18m },
                    { 115, 3, "Mussorgsky: Pictures at an Exhibition, Songs and Dances of Death, Night on Bare Mountain", 72.66m },
                    { 116, 3, "Classical Chillout", 18.38m },
                    { 117, 3, "French Impressions", 87.86m },
                    { 118, 3, "Vivaldi: The Four Seasons/Wind Concertos", 51.40m },
                    { 119, 3, "Faure: Requiem, Op. 48 / Pavane, Op. 50", 73.48m },
                    { 120, 3, "Beethoven: Piano Sonatas, Vol.3", 75.90m },
                    { 121, 3, "Linkages - Piano music by Brahms, Wagner, Schönberg a.o.", 18.61m },
                    { 122, 3, "Fragment", 97.79m },
                    { 123, 3, "Copland Conducts Copland - Expanded Edition (Fanfare for the Common Man, Appalachian Spring, Old American Songs (Complete), Rodeo: Four Dance Episodes)", 38.92m },
                    { 125, 3, "Rimsky-Korsakov: Scheherazade, Op. 35; Capriccio espagnol, Op. 34", 54.54m },
                    { 102, 3, "Riceboy Sleeps", 85.96m },
                    { 150, 3, "Ives: Symphony No. 3 / Washington's Birthday", 98.31m },
                    { 152, 4, "Jeremy", 72.15m },
                    { 178, 4, "Spirit (Deluxe)", 25.78m },
                    { 179, 4, "Born To Run", 93.87m },
                    { 180, 4, "Cross Road", 14.98m },
                    { 181, 4, "It's Not Over....The Hits So Far", 13.91m },
                    { 182, 4, "Surrealistic Pillow", 38.09m },
                    { 183, 4, "Supernatural (Remastered)", 35.36m },
                    { 184, 4, "Meteora", 52.73m },
                    { 185, 4, "Honky Chateau", 60.51m },
                    { 186, 4, "Keep The Faith", 40.21m },
                    { 187, 4, "Crazy World", 14.80m },
                    { 188, 4, "Nightmare", 95.30m },
                    { 189, 4, "The Better Life", 19.26m },
                    { 190, 4, "Simulation Theory (Super Deluxe)", 81.87m },
                    { 191, 4, "Veni Vidi Vicious", 45.74m },
                    { 192, 4, "Tom Petty & The Heartbreakers", 74.34m },
                    { 193, 4, "Hydrograd", 97.77m },
                    { 194, 4, "RARE", 19.22m },
                    { 195, 4, "Rebel Yell", 71.22m },
                    { 196, 4, "Led Zeppelin", 11.12m },
                    { 197, 4, "Every Six Seconds", 89.02m },
                    { 198, 4, "Rumours", 80.29m },
                    { 177, 4, "World Away", 41.04m },
                    { 151, 4, "American Fool", 85.14m },
                    { 176, 4, "Hot Fuss", 24.01m },
                    { 174, 4, "Facelift", 55.80m },
                    { 153, 4, "A Beautiful Lie", 75.35m },
                    { 154, 4, "Wild Frontier", 86.56m },
                    { 155, 4, "No More Tears (Expanded Edition)", 87.74m },
                    { 156, 4, "YOUNG&DANGEROUS", 14.35m },
                    { 157, 4, "Endgame", 57.95m },
                    { 158, 4, "For Crying Out Loud (Deluxe)", 77.39m },
                    { 159, 4, "Crazy World", 75.51m },
                    { 160, 4, "Straight Shooter", 80.94m },
                    { 161, 4, "Foreigner (Expanded)", 57.26m },
                    { 162, 4, "Going Grey", 34.57m },
                    { 163, 4, "Third Eye Blind", 16.38m },
                    { 164, 4, "11 Short Stories of Pain & Glory", 87.27m },
                    { 165, 4, "The Black Parade", 37.80m },
                    { 166, 4, "Wonder What's Next (Expanded Edition)", 76.33m },
                    { 167, 4, "Tranquility Base Hotel & Casino", 69.75m },
                    { 168, 4, "The Peace And The Panic", 11.20m },
                    { 169, 4, "Meteora (Bonus Edition)", 82.76m },
                    { 170, 4, "From Under The Cork Tree", 79.78m },
                    { 171, 4, "Amaryllis", 66.44m },
                    { 172, 4, "Lighting Matches (Deluxe)", 25.38m },
                    { 173, 4, "Ill Communication", 62.04m },
                    { 175, 4, "Are You Experienced", 52.02m },
                    { 101, 3, "Satie: Avant-dernières pensées (Bonus Track Version)", 12.24m },
                    { 100, 2, "O Descobridor Dos Sete Mares", 95.45m },
                    { 99, 2, "Recanto", 62.56m },
                    { 27, 1, "Glory Days: The Platinum Edition", 96.50m },
                    { 28, 1, "Morse Code", 58.01m },
                    { 29, 1, "Mr. Davis", 74.35m },
                    { 30, 1, "Good For You", 45.52m },
                    { 31, 1, "Red Pill Blues (Deluxe)", 87.15m },
                    { 32, 1, "VHS", 54.08m },
                    { 33, 1, "x (Deluxe Edition)", 31.13m },
                    { 34, 1, "Waves (Robin Schulz Radio Edit)", 95.27m },
                    { 35, 1, "Party's Over", 89.08m },
                    { 36, 1, "Views", 77.01m },
                    { 37, 1, "The Truth About Love", 66.77m },
                    { 38, 1, "Bangerz (Deluxe Version)", 58.56m },
                    { 39, 1, "DAMN.", 14.09m },
                    { 40, 1, "I Decided.", 96.91m },
                    { 41, 1, "Funk Wav Bounces Vol.1", 53.80m },
                    { 42, 1, "Something New", 19.68m },
                    { 43, 1, "÷ (Deluxe)", 60.09m },
                    { 44, 1, "PRISM (Deluxe)", 11.30m },
                    { 45, 1, "Bangerz (Deluxe Version)", 54.49m },
                    { 46, 1, "Bombs Away", 89.10m },
                    { 47, 1, "Perfect Strangers", 66.58m },
                    { 26, 1, "Made In The A.M. (Deluxe Edition)", 45.53m },
                    { 48, 1, "All This Bad Blood", 23.85m },
                    { 25, 1, "PARTYNEXTDOOR 3 (P3)", 75.86m },
                    { 23, 1, "Beach House 3", 45.02m },
                    { 2, 1, "ANTI (Deluxe)", 30.65m },
                    { 3, 1, "Playboi Carti", 34.50m },
                    { 4, 1, "Savage Mode", 30.90m },
                    { 5, 1, "Blank Face LP", 86.24m },
                    { 6, 1, "True", 87.62m },
                    { 7, 1, "More Life", 38.71m },
                    { 8, 1, "Only You (with Little Mix)", 70.38m },
                    { 9, 1, "Culture", 56.68m },
                    { 10, 1, "Funk Wav Bounces Vol.1", 35.88m },
                    { 11, 1, "From A Distance", 13.12m },
                    { 12, 1, "Rodeo (Expanded Edition)", 19.00m },
                    { 13, 1, "Still Brazy (Deluxe)", 75.89m },
                    { 14, 1, "Trigga Reloaded", 70.33m },
                    { 15, 1, "This Is What You Came For", 23.12m },
                    { 16, 1, "reputation", 30.52m },
                    { 17, 1, "The Bedroom Tour Playlist", 35.71m },
                    { 18, 1, "The Good Parts", 79.76m },
                    { 19, 1, "EVOL", 54.04m },
                    { 20, 1, "Oxymoron (Deluxe)", 61.85m },
                    { 21, 1, "This Is America", 33.99m },
                    { 22, 1, "Nothing Was The Same (Deluxe)", 77.47m },
                    { 24, 1, "I Cry When I Laugh", 46.25m },
                    { 49, 1, "Talking Dreams (Deluxe Version)", 65.27m },
                    { 50, 1, "Lady Wood", 29.82m },
                    { 51, 2, "De Lá Até Aqui", 96.95m },
                    { 78, 2, "Mais uma Página", 44.62m },
                    { 79, 2, "Volta", 91.65m },
                    { 80, 2, "Brasis", 86.66m },
                    { 81, 2, "De Lá Até Aqui", 78.85m },
                    { 82, 2, "Toni Ferreira", 83.54m },
                    { 83, 2, "Mais uma Página", 92.64m },
                    { 84, 2, "Chão", 55.43m },
                    { 85, 2, "Recanto", 48.48m },
                    { 86, 2, "Nós", 72.63m },
                    { 87, 2, "O Disco do Ano", 51.23m },
                    { 88, 2, "Baião de Dois", 89.87m },
                    { 89, 2, "Sinais dos Tempos", 52.50m },
                    { 90, 2, "Dani Black", 26.93m },
                    { 91, 2, "I Love MPB - O Nosso Amor A Gente Inventa", 91.38m },
                    { 92, 2, "Musica do Brasil Antonio Carlos Jobim \"Romántico\"", 78.52m },
                    { 93, 2, "O Disco do Ano", 14.52m },
                    { 94, 2, "Nós", 62.38m },
                    { 95, 2, "Brasis", 16.79m },
                    { 96, 2, "Volta", 73.10m },
                    { 97, 2, "Musica do Brasil Antonio Carlos Jobim \"Romántico\"", 23.65m },
                    { 98, 2, "Ana E Jorge", 48.93m },
                    { 77, 2, "I Love MPB - O Nosso Amor A Gente Inventa", 28.28m },
                    { 76, 2, "Fôlego", 25.21m },
                    { 75, 2, "ôÔÔôôÔôÔ", 18.95m },
                    { 74, 2, "De Lá Até Aqui", 57.03m },
                    { 52, 2, "O Disco do Ano", 25.42m },
                    { 53, 2, "Seu Jorge and Almaz", 13.75m },
                    { 54, 2, "I Love MPB - O Nosso Amor A Gente Inventa", 41.16m },
                    { 55, 2, "Nós", 53.67m },
                    { 56, 2, "A revolta dos ritmos", 73.06m },
                    { 57, 2, "Mais uma Página", 85.53m },
                    { 58, 2, "Meu Coração Não Quer Viver Batendo Devagar", 88.15m },
                    { 59, 2, "ôÔÔôôÔôÔ", 54.94m },
                    { 60, 2, "Feito Pra Acabar", 51.61m },
                    { 61, 2, "O Micróbio do Samba", 91.02m },
                    { 199, 4, "Can't Deny Me", 86.13m },
                    { 62, 2, "O Disco do Ano", 80.60m },
                    { 64, 2, "I Love MPB - O Nosso Amor A Gente Inventa", 22.06m },
                    { 65, 2, "É Proibido Fumar (Remasterizado)", 48.63m },
                    { 66, 2, "ôÔÔôôÔôÔ", 58.94m },
                    { 67, 2, "Mais uma Página", 87.76m },
                    { 68, 2, "Feito Pra Acabar", 80.52m },
                    { 69, 2, "Nós", 81.15m },
                    { 70, 2, "Vanessa da Mata canta Tom Jobim (Deluxe Edition)", 46.02m },
                    { 71, 2, "O Disco do Ano", 63.65m },
                    { 72, 2, "Ana E Jorge", 77.05m },
                    { 73, 2, "Mais uma Página", 76.57m },
                    { 63, 2, "Nós", 95.93m },
                    { 200, 4, "Revolution Radio", 94.72m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemSales_SaleId",
                schema: "VinylRecordSale",
                table: "ItemSales",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSales_VinylDiscId",
                schema: "VinylRecordSale",
                table: "ItemSales",
                column: "VinylDiscId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ClientId",
                schema: "VinylRecordSale",
                table: "Sales",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_VinylDiscs_MusicGenreId",
                schema: "VinylRecordSale",
                table: "VinylDiscs",
                column: "MusicGenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigCashbacks",
                schema: "VinylRecordSale");

            migrationBuilder.DropTable(
                name: "ItemSales",
                schema: "VinylRecordSale");

            migrationBuilder.DropTable(
                name: "Sales",
                schema: "VinylRecordSale");

            migrationBuilder.DropTable(
                name: "VinylDiscs",
                schema: "VinylRecordSale");

            migrationBuilder.DropTable(
                name: "Clients",
                schema: "VinylRecordSale");

            migrationBuilder.DropTable(
                name: "MusicGenres",
                schema: "VinylRecordSale");
        }
    }
}
