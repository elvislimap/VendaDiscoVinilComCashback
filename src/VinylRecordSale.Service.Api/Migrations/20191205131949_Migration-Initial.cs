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
                    { 1, "karlafranco59@hotmail.com", "Karla Franco" },
                    { 10, "salvadorsaraiva27@hotmail.com", "Salvador Saraiva" },
                    { 8, "dalilanogueira.Oliveira85@yahoo.com", "Dalila Nogueira" },
                    { 7, "alessandraoliveira.Oliveira43@hotmail.com", "Alessandra Oliveira" },
                    { 6, "isabelaalbuquerque_Saraiva@live.com", "Isabela Albuquerque" },
                    { 9, "raulalbuquerque62@gmail.com", "Raul Albuquerque" },
                    { 4, "juliasantos_Albuquerque29@yahoo.com", "Júlia Santos" },
                    { 3, "felicianobatista.Costa3@bol.com.br", "Feliciano Batista" },
                    { 2, "victorcarvalho.Barros@live.com", "Víctor Carvalho" },
                    { 5, "ceciliabarros85@hotmail.com", "Cecília Barros" }
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
                    { 1, 1, "Playboi Carti", 94.05m },
                    { 128, 3, "The Lighthouse Project", 45.69m },
                    { 129, 3, "The Very Best of Jessye Norman", 64.76m },
                    { 130, 3, "Ives: Symphony No. 3 / Washington's Birthday", 49.58m },
                    { 131, 3, "Music for Egon Schiele", 44.43m },
                    { 132, 3, "Liszt: Scherzo and March / 3 Liebestraume / Berceuse", 49.77m },
                    { 133, 3, "Scriabin: Piano Concerto / Prometheus", 77.48m },
                    { 134, 3, "Handel: Messiah", 17.18m },
                    { 135, 3, "Bartók: Concerto for Orchestra - Music for Strings, Percussion & Celesta", 54.22m },
                    { 136, 3, "Chopin: Complete Nocturnes", 75.55m },
                    { 137, 3, "Albinoni: Oboe Concertos, Vol. 2", 94.38m },
                    { 138, 3, "Schumann, C.: Songs (Complete)", 51.33m },
                    { 139, 3, "Schonberg : Verklärte Nacht, 5 Orchestral Pieces & Piano Works", 64.24m },
                    { 140, 3, "Copland Conducts Copland - Expanded Edition (Fanfare for the Common Man, Appalachian Spring, Old American Songs (Complete), Rodeo: Four Dance Episodes)", 70.74m },
                    { 141, 3, "The Fountain OST", 70.48m },
                    { 142, 3, "Tintomara", 87.94m },
                    { 143, 3, "Dvořák: Serenade for Strings, Czech Suite", 18.85m },
                    { 144, 3, "Handel: Messiah", 65.60m },
                    { 145, 3, "Legends Of The Fall Original Motion Picture Soundtrack", 69.22m },
                    { 146, 3, "Smetana: Ma Vlast (My Country)", 28.43m },
                    { 147, 3, "Xenakis, I.: Orchestral Works, Vol. 5 - Metastaseis / Pithoprakta / St/48 / Achorripsis / Syrmos / Hiketides Suite", 95.47m },
                    { 148, 3, "Beethoven: Symphony No. 3 \"Eroica\" & Leonore Overture", 93.52m },
                    { 127, 3, "Martinů: Cello Sonatas Nos. 1-3", 24.35m },
                    { 149, 3, "Harry Potter and The Sorcerer's Stone Original Motion Picture Soundtrack", 64.53m },
                    { 126, 3, "The Leftovers: Season 1 (Music from the HBO Series)", 17.30m },
                    { 124, 3, "Tchaikovsky: Serenade for Strings - Grieg: Holberg Suite - Mozart: Eine kleine Nachtmusik", 59.08m },
                    { 103, 3, "Scriabin: Vers la Flamme", 64.54m },
                    { 104, 3, "Copland Conducts Copland - Expanded Edition (Fanfare for the Common Man, Appalachian Spring, Old American Songs (Complete), Rodeo: Four Dance Episodes)", 35.55m },
                    { 105, 3, "Fauré: Violin Sonata in E minor / Franck: Violin Sonata in A etc.", 55.05m },
                    { 106, 3, "Wagner: Opera Orchestral Music", 92.63m },
                    { 107, 3, "Bach: Brandenburgische Konzerte", 11.70m },
                    { 108, 3, "The Age Of Puccini", 77.73m },
                    { 109, 3, "Legends Of The Fall Original Motion Picture Soundtrack", 62.75m },
                    { 110, 3, "Sibelius Finlandia (Best Of)", 51.28m },
                    { 111, 3, "Bartók, Khachaturian, Milhaud, Stravinsky: Clarinet Trios", 82.24m },
                    { 112, 3, "Szymanowski: Complete Piano Works", 12.21m },
                    { 113, 3, "The Art of Bach", 96.07m },
                    { 114, 3, "Adams, J.: Nixon in China", 19.52m },
                    { 115, 3, "Gershwin Plays Gershwin: The Piano Rolls", 56.32m },
                    { 116, 3, "Waghalter: Violin Concerto - Violin Sonata", 56.12m },
                    { 117, 3, "Faure (The Best Of)", 20.39m },
                    { 118, 3, "Bruckner: Symphony No. 8", 77.41m },
                    { 119, 3, "Rebirth of a Nation", 20.49m },
                    { 120, 3, "Pan's Labyrinth", 88.82m },
                    { 121, 3, "Hope Street Tunnel Blues: Music for Piano By Philip Glass and Alvin Curran", 22.39m },
                    { 122, 3, "Cinema Classics, Vol. 10", 91.37m },
                    { 123, 3, "Rimsky-Korsakov: Scheherazade, Op. 35; Capriccio espagnol, Op. 34", 21.92m },
                    { 125, 3, "Pärt: Piano Music", 40.68m },
                    { 102, 3, "Horowitz Plays Liszt", 77.66m },
                    { 150, 3, "Faure: Requiem, Op. 48 / Pavane, Op. 50", 45.70m },
                    { 152, 4, "The Canyon", 11.08m },
                    { 178, 4, "Echoes, Silence, Patience & Grace", 56.21m },
                    { 179, 4, "The Wall (Remastered)", 89.75m },
                    { 180, 4, "Human Clay", 23.15m },
                    { 181, 4, "Full Moon Fever", 21.72m },
                    { 182, 4, "Villains", 30.74m },
                    { 183, 4, "Ted Nugent", 81.06m },
                    { 184, 4, "Only By The Night", 29.96m },
                    { 185, 4, "Wolfmother", 95.29m },
                    { 186, 4, "Moving Pictures (2011 Remaster)", 44.25m },
                    { 187, 4, "Silver Side Up", 13.06m },
                    { 188, 4, "Marauder", 68.53m },
                    { 189, 4, "Disobey", 87.64m },
                    { 190, 4, "Something Like Human", 95.24m },
                    { 191, 4, "Are You Experienced", 19.80m },
                    { 192, 4, "I Don't Want To Miss A Thing", 88.92m },
                    { 193, 4, "One More Light", 56.46m },
                    { 194, 4, "11 Short Stories of Pain & Glory", 26.49m },
                    { 195, 4, "finding it hard to smile", 91.46m },
                    { 196, 4, "MANIA", 15.46m },
                    { 197, 4, "The Battle Of Los Angeles", 74.97m },
                    { 198, 4, "Ten Thousand Fists", 94.68m },
                    { 177, 4, "Ember", 83.42m },
                    { 151, 4, "The Atlas Underground", 54.19m },
                    { 176, 4, "Ring Of Fire: The Best Of Johnny Cash", 34.35m },
                    { 174, 4, "This Is War", 49.65m },
                    { 153, 4, "Use Your Illusion II", 47.61m },
                    { 154, 4, "Morning View", 19.85m },
                    { 155, 4, "Graveyard Shift", 29.44m },
                    { 156, 4, "Can't Knock The Hustle", 58.88m },
                    { 157, 4, "Vivid (Expanded Edition)", 66.65m },
                    { 158, 4, "Aqualung (Special Edition)", 16.36m },
                    { 159, 4, "Stone Temple Pilots (2018)", 94.77m },
                    { 160, 4, "Straight Shooter", 48.65m },
                    { 161, 4, "Document (R.E.M. No. 5)", 79.18m },
                    { 162, 4, "The Boy Who Died Wolf", 65.91m },
                    { 163, 4, "Escape", 23.87m },
                    { 164, 4, "American IV: The Man Comes Around", 24.07m },
                    { 165, 4, "Is This It", 17.76m },
                    { 166, 4, "Some Girls", 43.37m },
                    { 167, 4, "Who Are You", 34.62m },
                    { 168, 4, "Spotify Singles", 89.79m },
                    { 169, 4, "The Wrong Side Of Heaven And The Righteous Side Of Hell, Volume 1", 65.20m },
                    { 170, 4, "Toxicity", 80.67m },
                    { 171, 4, "...Like Clockwork", 61.64m },
                    { 172, 4, "Good Thing", 68.96m },
                    { 173, 4, "Rumours", 24.07m },
                    { 175, 4, "Paranoid (2009 Remastered Version)", 29.25m },
                    { 101, 3, "Haydn (The Best Of)", 50.34m },
                    { 100, 2, "A revolta dos ritmos", 40.93m },
                    { 99, 2, "Musica do Brasil Antonio Carlos Jobim \"Romántico\"", 97.77m },
                    { 27, 1, "The Marshall Mathers LP2", 23.49m },
                    { 28, 1, "OMG", 60.25m },
                    { 29, 1, "Heathens", 61.68m },
                    { 30, 1, "Let Me Hold You (Turn Me On)", 71.90m },
                    { 31, 1, "Culture II", 27.93m },
                    { 32, 1, "Views", 88.47m },
                    { 33, 1, "Skin", 36.02m },
                    { 34, 1, "A Head Full of Dreams", 68.58m },
                    { 35, 1, "I Decided.", 30.07m },
                    { 36, 1, "#willpower", 95.50m },
                    { 37, 1, "Life Changes", 35.12m },
                    { 38, 1, "The Human Condition", 15.53m },
                    { 39, 1, "Happier", 19.78m },
                    { 40, 1, "The Pinkprint (Deluxe Edition)", 95.24m },
                    { 41, 1, "SUBEME LA RADIO", 49.26m },
                    { 42, 1, "Starboy", 63.58m },
                    { 43, 1, "Non-Fiction (Deluxe)", 30.37m },
                    { 44, 1, "Lady Wood", 58.08m },
                    { 45, 1, "Globalization", 18.29m },
                    { 46, 1, "All My Friends (feat. Tinashe & Chance the Rapper)", 12.61m },
                    { 47, 1, "Grateful", 94.77m },
                    { 26, 1, "Tremaine The Album", 48.18m },
                    { 48, 1, "Rainbow", 64.38m },
                    { 25, 1, "Pray for the Wicked", 95.38m },
                    { 23, 1, "BEYONCÉ [Platinum Edition]", 33.53m },
                    { 2, 1, "This Is A Challenge", 99.30m },
                    { 3, 1, "After Laughter", 87.07m },
                    { 4, 1, "The 1975", 97.77m },
                    { 5, 1, "Luv Is Rage 2", 47.02m },
                    { 6, 1, "Views", 27.82m },
                    { 7, 1, "There for You", 45.83m },
                    { 8, 1, "Red Pill Blues (Deluxe)", 47.67m },
                    { 9, 1, "Boys", 45.07m },
                    { 10, 1, "Melodrama", 77.23m },
                    { 11, 1, "Still Got Time", 65.83m },
                    { 12, 1, "A Town Called Paradise", 87.29m },
                    { 13, 1, "Talking Dreams (Deluxe Version)", 85.69m },
                    { 14, 1, "Artist", 29.91m },
                    { 15, 1, "War & Leisure", 55.12m },
                    { 16, 1, "Just Hold On", 33.26m },
                    { 17, 1, "Your Song", 31.22m },
                    { 18, 1, "Black Panther The Album Music From And Inspired By", 64.62m },
                    { 19, 1, "From A Distance", 51.11m },
                    { 20, 1, "Midnight Memories (Deluxe)", 51.72m },
                    { 21, 1, "beerbongs & bentleys", 74.79m },
                    { 22, 1, "The Click", 26.54m },
                    { 24, 1, "My Dear Melancholy,", 54.59m },
                    { 49, 1, "I LOVE MAKONNEN", 84.17m },
                    { 50, 1, "2014 Forest Hills Drive", 53.19m },
                    { 51, 2, "I Love MPB - O Nosso Amor A Gente Inventa", 19.32m },
                    { 78, 2, "Nós", 75.36m },
                    { 79, 2, "Estampado", 47.21m },
                    { 80, 2, "Baião de Dois", 93.67m },
                    { 81, 2, "Roupa Nova", 53.31m },
                    { 82, 2, "Meu Coração Não Quer Viver Batendo Devagar", 59.01m },
                    { 83, 2, "Acabou Chorare", 75.98m },
                    { 84, 2, "Feito Pra Acabar", 19.39m },
                    { 85, 2, "Recanto", 63.47m },
                    { 86, 2, "Em Pleno Verão", 71.28m },
                    { 87, 2, "De Lá Até Aqui", 65.77m },
                    { 88, 2, "Acabou Chorare", 70.70m },
                    { 89, 2, "Brasis", 16.99m },
                    { 90, 2, "Nós", 51.56m },
                    { 91, 2, "Rua dos Amores", 29.74m },
                    { 92, 2, "Feito Pra Acabar", 91.64m },
                    { 93, 2, "Recanto", 13.14m },
                    { 94, 2, "Geraldo Azevedo", 20.95m },
                    { 95, 2, "A revolta dos ritmos", 90.91m },
                    { 96, 2, "Roupa Nova", 63.68m },
                    { 97, 2, "Nós", 77.58m },
                    { 98, 2, "O Micróbio do Samba", 57.20m },
                    { 77, 2, "A revolta dos ritmos", 96.07m },
                    { 76, 2, "Acabou Chorare", 22.11m },
                    { 75, 2, "O Micróbio do Samba", 13.37m },
                    { 74, 2, "Baião de Dois", 55.77m },
                    { 52, 2, "O Disco do Ano", 56.55m },
                    { 53, 2, "O Micróbio do Samba", 33.60m },
                    { 54, 2, "Mais uma Página", 65.22m },
                    { 55, 2, "Redescobrir (Live At Credicard Hall, São Paulo / 2012)", 62.50m },
                    { 56, 2, "Sinais dos Tempos", 78.41m },
                    { 57, 2, "I Love MPB - O Nosso Amor A Gente Inventa", 76.66m },
                    { 58, 2, "Acabou Chorare", 43.38m },
                    { 59, 2, "Feito Pra Acabar", 13.29m },
                    { 60, 2, "Geraldo Azevedo", 98.73m },
                    { 61, 2, "Vanessa da Mata canta Tom Jobim (Deluxe Edition)", 15.23m },
                    { 199, 4, "One By One (Expanded Edition)", 58.75m },
                    { 62, 2, "Nós", 85.47m },
                    { 64, 2, "Mais uma Página", 73.07m },
                    { 65, 2, "Toni Ferreira", 60.20m },
                    { 66, 2, "ôÔÔôôÔôÔ", 77.26m },
                    { 67, 2, "Nós", 62.17m },
                    { 68, 2, "A revolta dos ritmos", 28.01m },
                    { 69, 2, "Baião de Dois", 99.74m },
                    { 70, 2, "Brasis", 59.52m },
                    { 71, 2, "Nove", 98.04m },
                    { 72, 2, "Sinais dos Tempos", 26.59m },
                    { 73, 2, "Meu Coração Não Quer Viver Batendo Devagar", 55.74m },
                    { 63, 2, "Roupa Nova", 85.89m },
                    { 200, 4, "Greatest Hits", 36.75m }
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
