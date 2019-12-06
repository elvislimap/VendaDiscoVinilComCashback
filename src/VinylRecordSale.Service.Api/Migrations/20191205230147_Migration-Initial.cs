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
                    { 1, "pablomoreira79@yahoo.com", "Pablo Moreira" },
                    { 10, "yagocosta39@gmail.com", "Yago Costa" },
                    { 8, "marceloalbuquerque81@hotmail.com", "Marcelo Albuquerque" },
                    { 7, "kleberalbuquerque.Saraiva90@yahoo.com", "Kléber Albuquerque" },
                    { 6, "hugomelo41@gmail.com", "Hugo Melo" },
                    { 9, "antoniosilva_Albuquerque22@live.com", "Antônio Silva" },
                    { 4, "dalilamoraes.Oliveira88@bol.com.br", "Dalila Moraes" },
                    { 3, "silviabarros43@live.com", "Sílvia Barros" },
                    { 2, "talitaalbuquerque.Macedo@live.com", "Talita Albuquerque" },
                    { 5, "cesarmelo.Costa@live.com", "César Melo" }
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
                    { 1, 1, "Playboi Carti", 78.74m },
                    { 128, 3, "Strauss: Die Fledermaus", 50.25m },
                    { 129, 3, "Ravel : Orchestral works", 46.14m },
                    { 130, 3, "The Good, The Bad & The Ugly (Original Motion Picture Soundtrack)", 18.94m },
                    { 131, 3, "Romantic Favorites for Strings (Expanded Edition)", 47.70m },
                    { 132, 3, "Time Curve: Music for Piano by Philip Glass and William Duckworth", 48.48m },
                    { 133, 3, "Living Room Songs", 13.57m },
                    { 134, 3, "Sibelius: Pelleas and Melisande Suite, Musik zu einer Szene & 3 Pièces pour orchestre", 86.90m },
                    { 135, 3, "Monteverdi: Vespers of 1610", 12.82m },
                    { 136, 3, "Tchaikovsky: Swan Lake", 78.52m },
                    { 137, 3, "Bruckner: Motets", 30.16m },
                    { 138, 3, "Satie: Avant-dernières pensées (Bonus Track Version)", 53.56m },
                    { 139, 3, "Horowitz Plays Liszt", 55.78m },
                    { 140, 3, "Beethoven, Period.", 27.01m },
                    { 141, 3, "Hindemith: Mathis Der Maler / Symphonic Metamorphosis", 75.08m },
                    { 142, 3, "Dvořák: Symphony No. 9 \"New World\" - Varèse: Amériques (Live)", 56.64m },
                    { 143, 3, "Mussorgsky: Pictures at an Exhibition - Expanded Edition", 32.91m },
                    { 144, 3, "My Favorite Liszt", 80.24m },
                    { 145, 3, "In 27 Pieces: the Hilary Hahn Encores", 48.18m },
                    { 146, 3, "In a Landscape: Piano Music of John Cage", 44.27m },
                    { 147, 3, "Without Sinking", 75.57m },
                    { 148, 3, "Ralph Vaughan Williams & James MacMillan: Oboe Concertos", 12.24m },
                    { 127, 3, "Bizet (The Best Of)", 99.48m },
                    { 149, 3, "Christopher Tye: Latin & English Church Music", 17.06m },
                    { 126, 3, "Pops Britannia", 59.66m },
                    { 124, 3, "Jane Eyre - Original Motion Picture Soundtrack", 45.10m },
                    { 103, 3, "Dance Of The Blessed Spirits", 74.71m },
                    { 104, 3, "V For Vendetta (Music From The Motion Picture)", 66.79m },
                    { 105, 3, "Mahler, A.: 5 Lieder / 5 Gesange / 4 Lieder", 74.82m },
                    { 106, 3, "Hugo Original Score", 33.75m },
                    { 107, 3, "Schumann: Violin Concerto", 80.07m },
                    { 108, 3, "Yellow Lounge", 40.14m },
                    { 109, 3, "Prokofiev: Romeo and Juliet", 97.65m },
                    { 110, 3, "Book of Leaves", 35.29m },
                    { 111, 3, "Tchaikovsky: The Nutcracker (Standard Version)", 82.13m },
                    { 112, 3, "Klassik ohne Krise: Grandioser Gesang", 92.09m },
                    { 113, 3, "Sunrise of the Planetary Dream Collector", 13.65m },
                    { 114, 3, "Copland Conducts Copland - Expanded Edition (Fanfare for the Common Man, Appalachian Spring, Old American Songs (Complete), Rodeo: Four Dance Episodes)", 85.90m },
                    { 115, 3, "La Voce del Violoncello", 49.98m },
                    { 116, 3, "Mozart: Piano Sonatas K.309, K.332 & K.570", 62.54m },
                    { 117, 3, "Xenakis, I.: Orchestral Works, Vol. 5 - Metastaseis / Pithoprakta / St/48 / Achorripsis / Syrmos / Hiketides Suite", 23.86m },
                    { 118, 3, "Tintomara", 28.80m },
                    { 119, 3, "The Piano: Music From The Motion Picture", 88.60m },
                    { 120, 3, "Hope Street Tunnel Blues: Music for Piano By Philip Glass and Alvin Curran", 16.40m },
                    { 121, 3, "Szymanowski: Piano Works, Vol. 1", 98.70m },
                    { 122, 3, "Time Present And Time Past", 91.40m },
                    { 123, 3, "Solipsism", 46.13m },
                    { 125, 3, "Messiaen: Preludes / 4 Rhythmic Studies / Canteyodjaya", 88.79m },
                    { 102, 3, "Spectacular", 65.59m },
                    { 150, 3, "Handel Sarabande", 64.02m },
                    { 152, 4, "11 Short Stories of Pain & Glory", 38.91m },
                    { 178, 4, "Can't Knock The Hustle", 65.79m },
                    { 179, 4, "World Away", 96.82m },
                    { 180, 4, "Feed the Machine", 55.42m },
                    { 181, 4, "Simulation Theory (Super Deluxe)", 83.99m },
                    { 182, 4, "A Fever You Can't Sweat Out", 98.14m },
                    { 183, 4, "Are You Experienced", 44.10m },
                    { 184, 4, "Rebel Yell", 82.02m },
                    { 185, 4, "Rumours", 88.52m },
                    { 186, 4, "Blood Sugar Sex Magik (Deluxe Edition)", 19.69m },
                    { 187, 4, "Anthology", 42.92m },
                    { 188, 4, "Weathered", 69.17m },
                    { 189, 4, "Slippery When Wet", 29.90m },
                    { 190, 4, "For Crying Out Loud (Deluxe)", 35.96m },
                    { 191, 4, "Around the Fur", 59.06m },
                    { 192, 4, "The Better Life", 89.55m },
                    { 193, 4, "Blur [Special Edition]", 75.56m },
                    { 194, 4, "Nevermind (Deluxe Edition)", 40.61m },
                    { 195, 4, "Wired", 92.74m },
                    { 196, 4, "Home of the Strange", 45.26m },
                    { 197, 4, "And Justice for None (Deluxe)", 62.64m },
                    { 198, 4, "Billy Talent II", 43.20m },
                    { 177, 4, "Straight Shooter", 69.39m },
                    { 151, 4, "Good Thing", 30.31m },
                    { 176, 4, "The Attractions Of Youth", 52.96m },
                    { 174, 4, "Anon.", 72.50m },
                    { 153, 4, "5", 16.46m },
                    { 154, 4, "Vivid (Expanded Edition)", 44.30m },
                    { 155, 4, "Don't You Worry, Honey", 67.90m },
                    { 156, 4, "The Boy Who Died Wolf", 76.76m },
                    { 157, 4, "Are You Experienced", 30.36m },
                    { 158, 4, "in•ter a•li•a", 40.51m },
                    { 159, 4, "Charm City", 77.90m },
                    { 160, 4, "The Atlas Underground", 26.06m },
                    { 161, 4, "How To Be A Human Being", 34.17m },
                    { 162, 4, "Word Up! (The Remixes)", 40.72m },
                    { 163, 4, "Strange Days", 93.90m },
                    { 164, 4, "The Sound of Madness (International)", 89.61m },
                    { 165, 4, "Moving Pictures (2011 Remaster)", 87.49m },
                    { 166, 4, "Lovely Little Lonely", 44.55m },
                    { 167, 4, "Wolfmother", 89.43m },
                    { 168, 4, "Crazy World", 26.64m },
                    { 169, 4, "Every Six Seconds", 83.98m },
                    { 170, 4, "UP", 71.35m },
                    { 171, 4, "Vitalogy", 43.28m },
                    { 172, 4, "Come What(ever) May [10th Anniversary Edition]", 70.20m },
                    { 173, 4, "Quarter Past Midnight", 72.92m },
                    { 175, 4, "MOSAIC", 41.23m },
                    { 101, 3, "Faure: Requiem, Op. 48 / Pavane, Op. 50", 68.26m },
                    { 100, 2, "Nós", 66.70m },
                    { 99, 2, "De Lá Até Aqui", 49.80m },
                    { 27, 1, "Handwritten", 33.50m },
                    { 28, 1, "÷ (Deluxe)", 90.79m },
                    { 29, 1, "HNDRXX", 32.79m },
                    { 30, 1, "Major Lazer Essentials", 59.63m },
                    { 31, 1, "The Human Condition", 30.99m },
                    { 32, 1, "Oh Lord", 77.12m },
                    { 33, 1, "The 1975", 68.82m },
                    { 34, 1, "Lukas Graham", 33.72m },
                    { 35, 1, "bloom", 44.49m },
                    { 36, 1, "Calypso", 70.22m },
                    { 37, 1, "So Good", 34.87m },
                    { 38, 1, "Blank Face LP", 43.51m },
                    { 39, 1, "Magna Carta... Holy Grail", 39.53m },
                    { 40, 1, "SweetSexySavage (Deluxe)", 72.36m },
                    { 41, 1, "Culture", 65.78m },
                    { 42, 1, "Flicker (Deluxe)", 94.50m },
                    { 43, 1, "The Thrill Of It All (Special Edition)", 32.82m },
                    { 44, 1, "AVĪCI (01)", 99.65m },
                    { 45, 1, "Whole Heart", 51.49m },
                    { 46, 1, "Lil Uzi Vert vs. The World", 79.52m },
                    { 47, 1, "Silence", 16.55m },
                    { 26, 1, "The Color Of You", 49.87m },
                    { 48, 1, "Kamikaze", 39.43m },
                    { 25, 1, "So Good", 49.80m },
                    { 23, 1, "Promises (with Sam Smith)", 52.22m },
                    { 2, 1, "Lust For Life", 85.98m },
                    { 3, 1, "5 Seconds Of Summer", 50.84m },
                    { 4, 1, "Only Way Is Up (Deluxe)", 95.07m },
                    { 5, 1, "Love Someone", 33.26m },
                    { 6, 1, "Deadroses", 79.21m },
                    { 7, 1, "Blonde", 24.30m },
                    { 8, 1, "7/27 (Deluxe)", 70.49m },
                    { 9, 1, "9", 87.28m },
                    { 10, 1, "The Mack", 80.83m },
                    { 11, 1, "Just Hold On", 61.90m },
                    { 12, 1, "A Town Called Paradise", 80.08m },
                    { 13, 1, "All My Friends (feat. Tinashe & Chance the Rapper)", 73.67m },
                    { 14, 1, "Glory Days: The Platinum Edition", 98.20m },
                    { 15, 1, "digital druglord", 84.67m },
                    { 16, 1, "Heathens", 62.04m },
                    { 17, 1, "Happier", 30.43m },
                    { 18, 1, "Melodrama", 35.11m },
                    { 19, 1, "I Cry When I Laugh", 34.35m },
                    { 20, 1, "Oh My My (Deluxe)", 17.19m },
                    { 21, 1, "Bangerz (Deluxe Version)", 88.21m },
                    { 22, 1, "Red Pill Blues (Deluxe)", 64.66m },
                    { 24, 1, "The Beautiful & Damned", 94.29m },
                    { 49, 1, "Tell Me You Love Me (Deluxe)", 81.24m },
                    { 50, 1, "My House", 13.00m },
                    { 51, 2, "Baião de Dois", 20.67m },
                    { 78, 2, "É Proibido Fumar (Remasterizado)", 52.47m },
                    { 79, 2, "De Lá Até Aqui", 53.70m },
                    { 80, 2, "Meu Coração Não Quer Viver Batendo Devagar", 70.17m },
                    { 81, 2, "O Micróbio do Samba", 44.22m },
                    { 82, 2, "Baião de Dois", 93.97m },
                    { 83, 2, "Geraldo Azevedo", 20.45m },
                    { 84, 2, "Recanto", 30.70m },
                    { 85, 2, "Volta", 49.86m },
                    { 86, 2, "Acabou Chorare", 55.24m },
                    { 87, 2, "Baião de Dois", 85.88m },
                    { 88, 2, "Ana Car9lina+um", 30.66m },
                    { 89, 2, "Musica do Brasil Antonio Carlos Jobim \"Romántico\"", 15.63m },
                    { 90, 2, "Toni Ferreira", 30.41m },
                    { 91, 2, "Roupa Nova", 36.46m },
                    { 92, 2, "Acabou Chorare", 78.32m },
                    { 93, 2, "Vanessa da Mata canta Tom Jobim (Deluxe Edition)", 87.24m },
                    { 94, 2, "Fôlego", 56.13m },
                    { 95, 2, "Nós", 26.65m },
                    { 96, 2, "O Descobridor Dos Sete Mares", 43.27m },
                    { 97, 2, "O Disco do Ano", 56.81m },
                    { 98, 2, "Seu Jorge and Almaz", 94.16m },
                    { 77, 2, "Feito Pra Acabar", 42.74m },
                    { 76, 2, "O Disco do Ano", 93.61m },
                    { 75, 2, "Brasis", 51.31m },
                    { 74, 2, "Recanto", 61.89m },
                    { 52, 2, "I Love MPB - O Nosso Amor A Gente Inventa", 75.65m },
                    { 53, 2, "Multishow Ao Vivo Ana Carolina \"Dois Quartos\"", 91.13m },
                    { 54, 2, "Brasis", 49.06m },
                    { 55, 2, "Nós", 28.99m },
                    { 56, 2, "Volta", 24.98m },
                    { 57, 2, "Baião de Dois", 44.66m },
                    { 58, 2, "Amado Batista \"85\"", 56.45m },
                    { 59, 2, "Sinais dos Tempos", 56.17m },
                    { 60, 2, "Feito Pra Acabar", 83.29m },
                    { 61, 2, "Mais uma Página", 56.61m },
                    { 199, 4, "Hail to the King", 92.65m },
                    { 62, 2, "Nós", 33.41m },
                    { 64, 2, "Geraldo Azevedo", 38.56m },
                    { 65, 2, "Acabou Chorare", 60.75m },
                    { 66, 2, "Volta", 84.69m },
                    { 67, 2, "De Lá Até Aqui", 22.16m },
                    { 68, 2, "Meu Coração Não Quer Viver Batendo Devagar", 50.86m },
                    { 69, 2, "Sinais dos Tempos", 64.62m },
                    { 70, 2, "Vanessa da Mata canta Tom Jobim (Deluxe Edition)", 25.35m },
                    { 71, 2, "Fôlego", 38.08m },
                    { 72, 2, "Feito Pra Acabar", 86.82m },
                    { 73, 2, "Nós", 95.48m },
                    { 63, 2, "Toni Ferreira", 48.60m },
                    { 200, 4, "Ted Nugent", 14.53m }
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
