using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations
{
    public partial class refactorDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Framewokrs_Languages_LanguageId",
                schema: "dbo",
                table: "Framewokrs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Framewokrs",
                schema: "dbo",
                table: "Framewokrs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "dbo",
                table: "UserOperationClaims");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "dbo",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "dbo",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "dbo",
                table: "OtpAuthenticators");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "dbo",
                table: "OperationClaims");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "dbo",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "dbo",
                table: "EmailAuthenticators");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "dbo",
                table: "Framewokrs");

            migrationBuilder.RenameTable(
                name: "Framewokrs",
                schema: "dbo",
                newName: "Frameworks",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Framewokrs_LanguageId",
                schema: "dbo",
                table: "Frameworks",
                newName: "IX_Frameworks_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Frameworks",
                schema: "dbo",
                table: "Frameworks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Frameworks_Languages_LanguageId",
                schema: "dbo",
                table: "Frameworks",
                column: "LanguageId",
                principalSchema: "dbo",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Frameworks_Languages_LanguageId",
                schema: "dbo",
                table: "Frameworks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Frameworks",
                schema: "dbo",
                table: "Frameworks");

            migrationBuilder.RenameTable(
                name: "Frameworks",
                schema: "dbo",
                newName: "Framewokrs",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Frameworks_LanguageId",
                schema: "dbo",
                table: "Framewokrs",
                newName: "IX_Framewokrs_LanguageId");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "UserOperationClaims",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "SocialMedias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "RefreshTokens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "OtpAuthenticators",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "OperationClaims",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "Languages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "EmailAuthenticators",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "Framewokrs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Framewokrs",
                schema: "dbo",
                table: "Framewokrs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Framewokrs_Languages_LanguageId",
                schema: "dbo",
                table: "Framewokrs",
                column: "LanguageId",
                principalSchema: "dbo",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
