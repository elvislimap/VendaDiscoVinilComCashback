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
                    { 1, "eduardasantos78@gmail.com", "Eduarda Santos" },
                    { 10, "eduardamelo.Martins@hotmail.com", "Eduarda Melo" },
                    { 8, "gubiobraga_Macedo@bol.com.br", "Gúbio Braga" },
                    { 7, "saramoraes.Xavier@hotmail.com", "Sara Moraes" },
                    { 6, "margaridabarros.Braga14@live.com", "Margarida Barros" },
                    { 9, "dalilamoreira26@gmail.com", "Dalila Moreira" },
                    { 4, "ceciliasaraiva.Moreira75@bol.com.br", "Cecília Saraiva" },
                    { 3, "fabioalbuquerque_Reis@hotmail.com", "Fábio Albuquerque" },
                    { 2, "alexandremoraes.Silva@gmail.com", "Alexandre Moraes" },
                    { 5, "igorbraga77@bol.com.br", "Ígor Braga" }
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
                    { 1, 1, "Origins (Deluxe)", 70.36m },
                    { 128, 3, "Gesualdo: Sacred Music for Five Voices (Complete)", 65.92m },
                    { 129, 3, "Tchaikovsky: Overture \"1812\"; Marche slave / Borodin: In the Steppes; Polovtsian Dances / Rimsky-Korsakov: Russian Easter; Capriccio", 95.89m },
                    { 130, 3, "Strauss: Die Fledermaus", 68.97m },
                    { 131, 3, "12 Years A Slave (Music From and Inspired by the Motion Picture)", 44.57m },
                    { 132, 3, "Monteverdi: Teatro d'amore", 86.53m },
                    { 133, 3, "Hope Street Tunnel Blues: Music for Piano By Philip Glass and Alvin Curran", 48.06m },
                    { 134, 3, "Steve Reich: Different Trains - Triple Quartet - The Four Sections", 89.06m },
                    { 135, 3, "Stravinsky: Le Sacre Du Printemps 100th Anniversary Collectors Edition", 60.95m },
                    { 136, 3, "Schubert: Des fragments aux étoiles", 30.08m },
                    { 137, 3, "Ligeti / Farkas / Veress / Liszt / Dohnanyi / Weiner / Mihaly: Hungarian Cello Music", 82.00m },
                    { 138, 3, "Faure: Requiem, Op. 48 / Pavane, Op. 50", 28.23m },
                    { 139, 3, "Sibelius: Pelleas and Melisande Suite, Musik zu einer Szene & 3 Pièces pour orchestre", 33.85m },
                    { 140, 3, "Szymanowski: Mazurkas, Opp. 50 & 62", 64.30m },
                    { 141, 3, "Brahms & Stravinsky: Violin Concertos", 58.63m },
                    { 142, 3, "Horowitz Plays Liszt", 60.48m },
                    { 143, 3, "Last Night of the Proms", 86.49m },
                    { 144, 3, "Beethoven, Period.", 35.46m },
                    { 145, 3, "Szymanowski: Violin Sonata / Mythes / Notturne and Tarantella", 12.33m },
                    { 146, 3, "Time Present And Time Past", 55.61m },
                    { 147, 3, "Schumann: A Tribute to Bach", 65.29m },
                    { 148, 3, "Grieg: Lyric Pieces, Books 1 - 4, Opp. 12, 38, 43 and 47", 23.22m },
                    { 127, 3, "Debussy: Images Books 1 & 2; Arabesques; Rêverie etc", 83.79m },
                    { 149, 3, "Nikolai Kapustin. Works for Piano and Cello", 76.70m },
                    { 126, 3, "Bach: Cello Suites Nos. 1, 5 & 6", 82.16m },
                    { 124, 3, "Saman", 12.63m },
                    { 103, 3, "Gabrielli: Early Italian Cello Music - Complete Works for Violoncello", 37.57m },
                    { 104, 3, "Clara Schumann & Johannes Brahms", 76.16m },
                    { 105, 3, "Tchaikovsky: Serenade for Strings - Grieg: Holberg Suite - Mozart: Eine kleine Nachtmusik", 74.66m },
                    { 106, 3, "Ives: Symphony No. 3 / Washington's Birthday", 85.23m },
                    { 107, 3, "Bach, J.S.: Well-Tempered Clavier (The), Book 2", 50.65m },
                    { 108, 3, "Szymanowski: String Quartets / Stravinsky: Concertino", 43.89m },
                    { 109, 3, "The Platinum Collection", 19.80m },
                    { 110, 3, "Sinkovsky Plays and Sings Vivaldi", 43.33m },
                    { 111, 3, "Bartok: Concerto for Orchestra; Music for Strings, Percussion & Celesta; Hungarian Sketches", 29.58m },
                    { 112, 3, "Legends Of The Fall Original Motion Picture Soundtrack", 27.86m },
                    { 113, 3, "Mozart & Schubert: Works for Piano Duo (Expanded Edition)", 69.97m },
                    { 114, 3, "…And They Have Escaped the Weight of Darkness", 52.71m },
                    { 115, 3, "Astor Piazzolla: Escualo", 11.94m },
                    { 116, 3, "Quarto tempo (Fourth Time)", 27.65m },
                    { 117, 3, "Xenakis, I.: Orchestral Works, Vol. 5 - Metastaseis / Pithoprakta / St/48 / Achorripsis / Syrmos / Hiketides Suite", 33.04m },
                    { 118, 3, "Prokofiev: Romeo and Juliet", 15.34m },
                    { 119, 3, "Chopin: Complete Noctures, Barcarolle, Berceuse", 84.09m },
                    { 120, 3, "Sing with the Voice of Melody (10th Anniversary)", 78.78m },
                    { 121, 3, "Haydn (The Best Of)", 91.52m },
                    { 122, 3, "Inception (Music From The Motion Picture)", 67.98m },
                    { 123, 3, "Praetorius: Dances From Terpsichore", 29.61m },
                    { 125, 3, "Fugue State", 97.93m },
                    { 102, 3, "Romantic Favorites for Strings (Expanded Edition)", 55.22m },
                    { 150, 3, "Mezopotamya Senfonisi No.2 , Op.38 - Universe Senfonisi No.3, Op.43", 82.99m },
                    { 152, 4, "Aerosmith", 37.80m },
                    { 178, 4, "House of Gold & Bones, Part 1", 94.05m },
                    { 179, 4, "Crooked Teeth (Deluxe)", 11.21m },
                    { 180, 4, "5", 53.22m },
                    { 181, 4, "RIOT!", 27.77m },
                    { 182, 4, "Crazy World", 71.46m },
                    { 183, 4, "Parallel Lines (Remastered)", 89.13m },
                    { 184, 4, "Paranoid (2009 Remastered Version)", 23.80m },
                    { 185, 4, "Permission To Land", 55.57m },
                    { 186, 4, "The River", 17.68m },
                    { 187, 4, "Surrealistic Pillow", 26.19m },
                    { 188, 4, "Terrible Human Beings", 93.38m },
                    { 189, 4, "Lighting Matches (Deluxe)", 27.70m },
                    { 190, 4, "Around the World and Back (Deluxe)", 70.09m },
                    { 191, 4, "Throwing Copper", 93.47m },
                    { 192, 4, "Nation Of Two", 57.06m },
                    { 193, 4, "Wish", 50.00m },
                    { 194, 4, "Lovely Little Lonely", 41.35m },
                    { 195, 4, "Escape", 62.86m },
                    { 196, 4, "Are You Experienced", 73.90m },
                    { 197, 4, "Don't You Worry, Honey", 23.48m },
                    { 198, 4, "A Fever You Can't Sweat Out", 46.66m },
                    { 177, 4, "American IV: The Man Comes Around", 81.39m },
                    { 151, 4, "Trench", 24.31m },
                    { 176, 4, "As You Were (Deluxe Edition)", 41.94m },
                    { 174, 4, "Synchronicity (Remastered 2003)", 30.69m },
                    { 153, 4, "Tranquility Base Hotel & Casino", 71.25m },
                    { 154, 4, "By the Way (Deluxe Edition)", 54.58m },
                    { 155, 4, "Seal The Deal & Let's Boogie (Deluxe)", 72.26m },
                    { 156, 4, "New Jersey (Deluxe Edition)", 90.76m },
                    { 157, 4, "Significant Other", 36.52m },
                    { 158, 4, "Machine Head (Remastered)", 35.83m },
                    { 159, 4, "Shake Your Money Maker", 78.13m },
                    { 160, 4, "Jeremy", 92.40m },
                    { 161, 4, "Girls, Girls, Girls", 12.34m },
                    { 162, 4, "AMERICA", 84.62m },
                    { 163, 4, "The Atlas Underground", 47.90m },
                    { 164, 4, "Run For Cover", 50.73m },
                    { 165, 4, "...Like Clockwork", 98.66m },
                    { 166, 4, "Rumours", 42.94m },
                    { 167, 4, "Heaven & Hell", 79.70m },
                    { 168, 4, "Coming Home (Deluxe Edition)", 80.81m },
                    { 169, 4, "Wolfmother", 91.66m },
                    { 170, 4, "Wild Cat", 81.76m },
                    { 171, 4, "Generation Rx", 45.55m },
                    { 172, 4, "Wednesday Morning, 3 A.M.", 15.71m },
                    { 173, 4, "Last Young Renegade", 81.39m },
                    { 175, 4, "The Black Parade", 31.05m },
                    { 101, 3, "Stucky: Dreamwaltzes / Chen: Duo Ye / Kilar: Krzesany", 58.84m },
                    { 100, 2, "Nós", 63.88m },
                    { 99, 2, "Feito Pra Acabar", 33.45m },
                    { 27, 1, "In My Mind", 68.17m },
                    { 28, 1, "YOUTH", 40.43m },
                    { 29, 1, "New", 79.09m },
                    { 30, 1, "Turn Down for What", 72.98m },
                    { 31, 1, "Late Nights: The Album", 81.99m },
                    { 32, 1, "Purple Lamborghini (with Rick Ross)", 33.29m },
                    { 33, 1, "Red Pill Blues (Deluxe)", 19.92m },
                    { 34, 1, "Good For You", 76.33m },
                    { 35, 1, "Safe Haven", 80.85m },
                    { 36, 1, "Views", 60.24m },
                    { 37, 1, "HAIZ", 47.58m },
                    { 38, 1, "Project Baby 2", 26.83m },
                    { 39, 1, "Flicker (Deluxe)", 53.29m },
                    { 40, 1, "Kiss", 36.26m },
                    { 41, 1, "Red Pill Blues (Deluxe)", 62.17m },
                    { 42, 1, "Lady Wood", 44.39m },
                    { 43, 1, "Chaos And The Calm", 78.35m },
                    { 44, 1, "PARTYNEXTDOOR 3 (P3)", 99.81m },
                    { 45, 1, "Campaign", 49.07m },
                    { 46, 1, "Solo (feat. Demi Lovato)", 22.42m },
                    { 47, 1, "I met you when I was 18. (the playlist)", 41.92m },
                    { 26, 1, "Who You Are (Platinum Edition)", 16.43m },
                    { 48, 1, "ANTI (Deluxe)", 59.40m },
                    { 25, 1, "Whippin (feat. Felix Snow)", 31.42m },
                    { 23, 1, "A Star Is Born Soundtrack", 70.52m },
                    { 2, 1, "÷ (Deluxe)", 58.20m },
                    { 3, 1, "PARTYNEXTDOOR TWO", 14.43m },
                    { 4, 1, "Starboy", 82.21m },
                    { 5, 1, "Made In The A.M. (Deluxe Edition)", 80.98m },
                    { 6, 1, "Light of Mine", 93.68m },
                    { 7, 1, "Free TC", 56.16m },
                    { 8, 1, "This Is A Challenge", 81.25m },
                    { 9, 1, "Know-It-All (Deluxe)", 95.89m },
                    { 10, 1, "Queen", 59.34m },
                    { 11, 1, "Heartbreak on a Full Moon", 18.48m },
                    { 12, 1, "SremmLife 2 (Deluxe)", 72.50m },
                    { 13, 1, "A Head Full of Dreams", 63.02m },
                    { 14, 1, "Major Key", 13.68m },
                    { 15, 1, "The Mack", 30.94m },
                    { 16, 1, "DAMN.", 54.30m },
                    { 17, 1, "7/27 (Deluxe)", 64.85m },
                    { 18, 1, "Body Say", 86.15m },
                    { 19, 1, "Funk Wav Bounces Vol.1", 32.09m },
                    { 20, 1, "Let Me Live (feat. Anne-Marie & Mr Eazi)", 66.80m },
                    { 21, 1, "DUMMY BOY", 20.41m },
                    { 22, 1, "Boys", 20.52m },
                    { 24, 1, "Young And Beautiful", 91.22m },
                    { 49, 1, "Pretty Girls Like Trap Music", 46.85m },
                    { 50, 1, "1, 2, 3 (feat. Jason Derulo & De La Ghetto)", 81.38m },
                    { 51, 2, "A revolta dos ritmos", 34.25m },
                    { 78, 2, "Acabou Chorare", 70.61m },
                    { 79, 2, "Meu Coração Não Quer Viver Batendo Devagar", 53.04m },
                    { 80, 2, "Ana Car9lina+um", 19.89m },
                    { 81, 2, "ôÔÔôôÔôÔ", 74.41m },
                    { 82, 2, "I Love MPB - O Nosso Amor A Gente Inventa", 19.66m },
                    { 83, 2, "Nós", 93.48m },
                    { 84, 2, "De Lá Até Aqui", 97.61m },
                    { 85, 2, "Recanto", 49.63m },
                    { 86, 2, "Geraldo Azevedo", 98.38m },
                    { 87, 2, "Acabou Chorare", 93.47m },
                    { 88, 2, "Volta", 95.40m },
                    { 89, 2, "Nós", 67.89m },
                    { 90, 2, "Musica do Brasil Antonio Carlos Jobim \"Romántico\"", 31.00m },
                    { 91, 2, "De Lá Até Aqui", 72.57m },
                    { 92, 2, "Meu Coração Não Quer Viver Batendo Devagar", 35.36m },
                    { 93, 2, "Rua dos Amores", 65.03m },
                    { 94, 2, "O Micróbio do Samba", 77.74m },
                    { 95, 2, "Mais uma Página", 99.74m },
                    { 96, 2, "Vanessa da Mata canta Tom Jobim (Deluxe Edition)", 46.45m },
                    { 97, 2, "ôÔÔôôÔôÔ", 42.24m },
                    { 98, 2, "Multishow Ao Vivo Ana Carolina \"Dois Quartos\"", 55.43m },
                    { 77, 2, "Sinais dos Tempos", 42.07m },
                    { 76, 2, "Vanessa da Mata canta Tom Jobim (Deluxe Edition)", 75.91m },
                    { 75, 2, "Roupa Nova", 15.52m },
                    { 74, 2, "Nós", 95.73m },
                    { 52, 2, "Nós", 83.51m },
                    { 53, 2, "Feito Pra Acabar", 39.72m },
                    { 54, 2, "ôÔÔôôÔôÔ", 24.42m },
                    { 55, 2, "Geraldo Azevedo", 19.34m },
                    { 56, 2, "A revolta dos ritmos", 60.74m },
                    { 57, 2, "O Disco do Ano", 87.57m },
                    { 58, 2, "Acabou Chorare", 23.12m },
                    { 59, 2, "Musica do Brasil Antonio Carlos Jobim \"Romántico\"", 61.70m },
                    { 60, 2, "É Proibido Fumar (Remasterizado)", 75.45m },
                    { 61, 2, "Baião de Dois", 36.41m },
                    { 199, 4, "American Fool", 36.70m },
                    { 62, 2, "A revolta dos ritmos", 26.63m },
                    { 64, 2, "Vanessa da Mata canta Tom Jobim (Deluxe Edition)", 33.82m },
                    { 65, 2, "Tim Maia 1973", 77.26m },
                    { 66, 2, "Volta", 85.09m },
                    { 67, 2, "Toni Ferreira", 63.48m },
                    { 68, 2, "Feito Pra Acabar", 86.59m },
                    { 69, 2, "Brasis", 32.74m },
                    { 70, 2, "Seu Jorge and Almaz", 70.60m },
                    { 71, 2, "Rua dos Amores", 17.62m },
                    { 72, 2, "Meu Coração Não Quer Viver Batendo Devagar", 48.92m },
                    { 73, 2, "A revolta dos ritmos", 43.76m },
                    { 63, 2, "Acabou Chorare", 13.06m },
                    { 200, 4, "Egypt Station", 69.28m }
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
