using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHURALE.Migrations
{
    /// <inheritdoc />
    public partial class KhakMigr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    CaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotherBoardFormFactor = table.Column<string>(type: "nvarchar(86)", maxLength: 86, nullable: true),
                    PowerSupplyFormFactor = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cases__6CAE526CF988E6CD", x => x.CaseID);
                });

            migrationBuilder.CreateTable(
                name: "Coolers",
                columns: table => new
                {
                    CoolerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SocketSupport = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ConstructionType = table.Column<string>(type: "nvarchar(33)", maxLength: 33, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Coolers__E5C71B68AD626730", x => x.CoolerID);
                });

            migrationBuilder.CreateTable(
                name: "CPUs",
                columns: table => new
                {
                    CPUID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Socket = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cores = table.Column<int>(type: "int", nullable: true),
                    Threads = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CPUs__7D9B6772B23C65AB", x => x.CPUID);
                });

            migrationBuilder.CreateTable(
                name: "GPUs",
                columns: table => new
                {
                    GPUID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VideoMemoryType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ConnectionInterface = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GPUs__8A41A909D70BE25B", x => x.GPUID);
                });

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Guest__3213E83F9AA856FD", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    MotherboardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Socket = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RAMType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ConnectionInterface = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    MemoryInterface = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Motherbo__08FE22E6F55DC9F6", x => x.MotherboardID);
                });

            migrationBuilder.CreateTable(
                name: "PowerSupply",
                columns: table => new
                {
                    PowerSupplyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PowerRating = table.Column<int>(type: "int", nullable: true),
                    FormFactor = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PowerSup__0E834E68148F63CB", x => x.PowerSupplyID);
                });

            migrationBuilder.CreateTable(
                name: "RAMs",
                columns: table => new
                {
                    RAMID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MemoryType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RAMs__0CB205236B2D4B17", x => x.RAMID);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    StorageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MemoryType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    MemoryInterface = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Storage__8A247E3739B85EB5", x => x.StorageID);
                });

            migrationBuilder.CreateTable(
                name: "CaseToMotherboardCompat",
                columns: table => new
                {
                    CaseID = table.Column<int>(type: "int", nullable: false),
                    MotherboardID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CaseToMo__1C21B0424FA7FE62", x => new { x.CaseID, x.MotherboardID });
                    table.ForeignKey(
                        name: "FK__CaseToMot__CaseI__5535A963",
                        column: x => x.CaseID,
                        principalTable: "Cases",
                        principalColumn: "CaseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__CaseToMot__Mothe__5629CD9C",
                        column: x => x.MotherboardID,
                        principalTable: "Motherboards",
                        principalColumn: "MotherboardID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoolerMotherboardCompat",
                columns: table => new
                {
                    CoolerID = table.Column<int>(type: "int", nullable: false),
                    MotherboardID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CoolerMo__9548F946ABFBA31E", x => new { x.CoolerID, x.MotherboardID });
                    table.ForeignKey(
                        name: "FK__CoolerMot__Coole__5165187F",
                        column: x => x.CoolerID,
                        principalTable: "Coolers",
                        principalColumn: "CoolerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__CoolerMot__Mothe__52593CB8",
                        column: x => x.MotherboardID,
                        principalTable: "Motherboards",
                        principalColumn: "MotherboardID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CPUToMotherboardCompat",
                columns: table => new
                {
                    CPUID = table.Column<int>(type: "int", nullable: false),
                    MotherboardID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CPUToMot__0D14855CA4C12689", x => new { x.CPUID, x.MotherboardID });
                    table.ForeignKey(
                        name: "FK__CPUToMoth__CPUID__5CD6CB2B",
                        column: x => x.CPUID,
                        principalTable: "CPUs",
                        principalColumn: "CPUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__CPUToMoth__Mothe__5DCAEF64",
                        column: x => x.MotherboardID,
                        principalTable: "Motherboards",
                        principalColumn: "MotherboardID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GPUToMotherboardCompat",
                columns: table => new
                {
                    GPUID = table.Column<int>(type: "int", nullable: false),
                    MotherboardID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GPUToMot__FACE4B2785D4F973", x => new { x.GPUID, x.MotherboardID });
                    table.ForeignKey(
                        name: "FK__GPUToMoth__GPUID__60A75C0F",
                        column: x => x.GPUID,
                        principalTable: "GPUs",
                        principalColumn: "GPUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__GPUToMoth__Mothe__619B8048",
                        column: x => x.MotherboardID,
                        principalTable: "Motherboards",
                        principalColumn: "MotherboardID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PowerSupplyCaseCompat",
                columns: table => new
                {
                    PowerSupplyID = table.Column<int>(type: "int", nullable: false),
                    CaseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PowerSup__D849AB4E255FDE62", x => new { x.PowerSupplyID, x.CaseID });
                    table.ForeignKey(
                        name: "FK__PowerSupp__CaseI__656C112C",
                        column: x => x.CaseID,
                        principalTable: "Cases",
                        principalColumn: "CaseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__PowerSupp__Power__6477ECF3",
                        column: x => x.PowerSupplyID,
                        principalTable: "PowerSupply",
                        principalColumn: "PowerSupplyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotherboardRAMCompat",
                columns: table => new
                {
                    MotherboardID = table.Column<int>(type: "int", nullable: false),
                    RAMID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Motherbo__283502B4E493F204", x => new { x.MotherboardID, x.RAMID });
                    table.ForeignKey(
                        name: "FK_MotherboardRAMCompat_Motherboards",
                        column: x => x.MotherboardID,
                        principalTable: "Motherboards",
                        principalColumn: "MotherboardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Motherboa__RAMID__59FA5E80",
                        column: x => x.RAMID,
                        principalTable: "RAMs",
                        principalColumn: "RAMID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StorageToMotherboardCompat",
                columns: table => new
                {
                    MotherboardID = table.Column<int>(type: "int", nullable: false),
                    StorageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageToMotherboardCompat", x => new { x.MotherboardID, x.StorageID });
                    table.ForeignKey(
                        name: "FK_StorageToMotherboardCompat_Motherboards",
                        column: x => x.MotherboardID,
                        principalTable: "Motherboards",
                        principalColumn: "MotherboardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorageToMotherboardCompat_Storage",
                        column: x => x.StorageID,
                        principalTable: "Storage",
                        principalColumn: "StorageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseToMotherboardCompat_MotherboardID",
                table: "CaseToMotherboardCompat",
                column: "MotherboardID");

            migrationBuilder.CreateIndex(
                name: "IX_CoolerMotherboardCompat_MotherboardID",
                table: "CoolerMotherboardCompat",
                column: "MotherboardID");

            migrationBuilder.CreateIndex(
                name: "IX_CPUToMotherboardCompat_MotherboardID",
                table: "CPUToMotherboardCompat",
                column: "MotherboardID");

            migrationBuilder.CreateIndex(
                name: "IX_GPUToMotherboardCompat_MotherboardID",
                table: "GPUToMotherboardCompat",
                column: "MotherboardID");

            migrationBuilder.CreateIndex(
                name: "IX_MotherboardRAMCompat_RAMID",
                table: "MotherboardRAMCompat",
                column: "RAMID");

            migrationBuilder.CreateIndex(
                name: "IX_PowerSupplyCaseCompat_CaseID",
                table: "PowerSupplyCaseCompat",
                column: "CaseID");

            migrationBuilder.CreateIndex(
                name: "IX_StorageToMotherboardCompat_StorageID",
                table: "StorageToMotherboardCompat",
                column: "StorageID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseToMotherboardCompat");

            migrationBuilder.DropTable(
                name: "CoolerMotherboardCompat");

            migrationBuilder.DropTable(
                name: "CPUToMotherboardCompat");

            migrationBuilder.DropTable(
                name: "GPUToMotherboardCompat");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "MotherboardRAMCompat");

            migrationBuilder.DropTable(
                name: "PowerSupplyCaseCompat");

            migrationBuilder.DropTable(
                name: "StorageToMotherboardCompat");

            migrationBuilder.DropTable(
                name: "Coolers");

            migrationBuilder.DropTable(
                name: "CPUs");

            migrationBuilder.DropTable(
                name: "GPUs");

            migrationBuilder.DropTable(
                name: "RAMs");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "PowerSupply");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "Storage");
        }
    }
}
