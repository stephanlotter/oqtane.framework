using Oqtane.Shared;
using Xunit;

namespace Oqtane.Test.Oqtane.Shared.Tests
{
    public class PluralizationTests
    {
        [Theory]
        [InlineData("Blog", "Blogs")]
        [InlineData("Inventory", "Inventories")]
        [InlineData("", "")]
        public void PluralizationTest(string singular, string expected)
        {
            // Arrange
            var actual = string.Empty;

            // Act
            actual = Pluralization.Pluralize(singular);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Test.input.[Module]s.value", "Blog", "Test.input.Blogs.value")]
        [InlineData("Test.input.[Module]s.value", "Inventory", "Test.input.Inventories.value")]
        [InlineData("Test input [Module]s value", "Inventory", "Test input Inventories value")]
        [InlineData("Test.input.[Module].value", "Inventory", "Test.input.Inventory.value")]
        [InlineData("Test input [Module] value", "Inventory", "Test input Inventory value")]
        [InlineData("@inject I[Module]Service [Module]Service", "Inventory", "@inject IInventoryService InventoryService")]
        [InlineData("                [Module] [Module] = new [Module]();", "Inventory", "                Inventory Inventory = new Inventory();")]
        [InlineData("", "", "")]
        public void ReplaceModuleWithPluralTest(string input, string singular, string expected)
        {
            // Arrange
            var actual = string.Empty;

            // Act
            actual = Pluralization.ReplaceModuleWithPlural(input, singular);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReplaceModuleWithPluralMultiLineSingleAndPluralTest()
        {
            var singular = "Inventory";
            var input = @"            if (PageState.Action == 'Edit')
            {
                [Module] [Module]s[];
                _id = Int32.Parse(PageState.QueryString['id']);
                [Module] [Module] = await [Module] Service.Get[Module]Async(_id);
                if ([Module] != null)
                {
                    _name = [Module].Name;
                    _createdby = [Module].CreatedBy;
                    _createdon = [Module].CreatedOn;
                    _modifiedby = [Module].ModifiedBy;
                    _modifiedon = [Module].ModifiedOn;
                }
            }";

            var expected = @"            if (PageState.Action == 'Edit')
            {
                Inventory Inventories[];
                _id = Int32.Parse(PageState.QueryString['id']);
                Inventory Inventory = await Inventory Service.GetInventoryAsync(_id);
                if (Inventory != null)
                {
                    _name = Inventory.Name;
                    _createdby = Inventory.CreatedBy;
                    _createdon = Inventory.CreatedOn;
                    _modifiedby = Inventory.ModifiedBy;
                    _modifiedon = Inventory.ModifiedOn;
                }
            }";

            // Arrange
            var actual = string.Empty;

            // Act
            actual = Pluralization.ReplaceModuleWithPlural(input, singular);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReplaceModuleWithPluralMultiLineTest()
        {
            var singular = "Inventory";
            var input = @"            if (PageState.Action == 'Edit')
            {
                _id = Int32.Parse(PageState.QueryString['id']);
                [Module] [Module] = await [Module] Service.Get[Module]Async(_id);
                if ([Module] != null)
                {
                    _name = [Module].Name;
                    _createdby = [Module].CreatedBy;
                    _createdon = [Module].CreatedOn;
                    _modifiedby = [Module].ModifiedBy;
                    _modifiedon = [Module].ModifiedOn;
                }
            }";

            var expected = @"            if (PageState.Action == 'Edit')
            {
                _id = Int32.Parse(PageState.QueryString['id']);
                Inventory Inventory = await Inventory Service.GetInventoryAsync(_id);
                if (Inventory != null)
                {
                    _name = Inventory.Name;
                    _createdby = Inventory.CreatedBy;
                    _createdon = Inventory.CreatedOn;
                    _modifiedby = Inventory.ModifiedBy;
                    _modifiedon = Inventory.ModifiedOn;
                }
            }";

            // Arrange
            var actual = string.Empty;

            // Act
            actual = Pluralization.ReplaceModuleWithPlural(input, singular);

            // Assert
            Assert.Equal(expected, actual);
        }
    }

}