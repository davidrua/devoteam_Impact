namespace Assignment.Tests.Tests
{
    using Assignment.B.LinkedLists;
    using FluentAssertions;
    using System;
    using Xunit;

    public class LinkedListTests
    {
        #region Tests

        [Fact]
        public void ShouldBeSuccess___CreateEmptyList()
        {
            #region Act

            var linkedList = new LinkedList<string>();

            #endregion Act

            #region Assert

            linkedList.Should().NotBeNull();
            linkedList.Should().BeEmpty();
            linkedList.Count.Should().Be(0);

            #endregion Assert
        }

        [Fact]
        public void ShouldBeSuccess___AddFirstToEmptyList()
        {
            #region Act

            var linkedList = new LinkedList<string>();
            var item_data = "item_data";
            linkedList.AddFirst(item_data);

            #endregion Act

            #region Assert

            linkedList.Should().NotBeNull();
            linkedList.Should().NotBeEmpty();
            linkedList.Count.Should().Be(1);
            var item = linkedList[0];
            item.Should().Be(item_data);

            #endregion Assert
        }

        [Fact]
        public void ShouldBeSuccess___AddFirstToListWith1Item()
        {
            #region Act

            var linkedList = new LinkedList<string>();
            var item1_data = "item1_data";
            var item2_data = "item2_data";
            linkedList.AddFirst(item2_data);
            linkedList.AddFirst(item1_data);

            #endregion Act

            #region Assert

            linkedList.Should().NotBeNull();
            linkedList.Should().NotBeEmpty();
            linkedList.Count.Should().Be(2);
            var item = linkedList[0];
            item.Should().Be(item1_data);
            item = linkedList[1];
            item.Should().Be(item2_data);

            #endregion Assert
        }

        [Fact]
        public void ShouldBeSuccess___AddLastToEmptyList()
        {
            #region Act

            var linkedList = new LinkedList<string>();
            var item_data = "item_data";
            linkedList.AddLast(item_data);

            #endregion Act

            #region Assert

            linkedList.Should().NotBeNull();
            linkedList.Should().NotBeEmpty();
            linkedList.Count.Should().Be(1);
            var item = linkedList[0];
            item.Should().Be(item_data);

            #endregion Assert
        }

        [Fact]
        public void ShouldBeSuccess___AddLastToListWith1Item()
        {
            #region Act

            var linkedList = new LinkedList<string>();
            var item1_data = "item1_data";
            var item2_data = "item2_data";
            linkedList.AddLast(item1_data);
            linkedList.AddLast(item2_data);

            #endregion Act

            #region Assert

            linkedList.Should().NotBeNull();
            linkedList.Should().NotBeEmpty();
            linkedList.Count.Should().Be(2);
            var item = linkedList[0];
            item.Should().Be(item1_data);
            item = linkedList[1];
            item.Should().Be(item2_data);

            #endregion Assert
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(2)]
        public void ShouldFail___Throw_ArgumentOutOfRangeException___Indexer___Get(int index)
        {
            #region Arrange

            var linkedList = new LinkedList<string>();
            var item1_data = "item1_data";
            var item2_data = "item2_data";
            linkedList.AddFirst(item2_data);
            linkedList.AddFirst(item1_data);

            #endregion Arrange

            #region Act

            Func<string> act = () => linkedList[index];

            #endregion Act

            #region Assert

            act.Should().Throw<ArgumentOutOfRangeException>()
                            .WithParameterName("index");

            #endregion Assert
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(2)]
        public void ShouldFail___Throw_ArgumentOutOfRangeException___Indexer___Set(int index)
        {
            #region Arrange

            var linkedList = new LinkedList<string>();
            var item1_data = "item1_data";
            var item2_data = "item2_data";
            linkedList.AddFirst(item2_data);
            linkedList.AddFirst(item1_data);

            #endregion Arrange

            #region Act

            var newData = $"item{index}_data";
            Func<string> act = () => linkedList[index] = newData;

            #endregion Act

            #region Assert

            act.Should().Throw<ArgumentOutOfRangeException>()
                            .WithParameterName("index");

            #endregion Assert
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void ShouldBeSuccess___Indexer___Get(int index)
        {
            #region Arrange

            var linkedList = new LinkedList<string>();
            var item1_data = "item1_data";
            var item2_data = "item2_data";
            linkedList.AddFirst(item2_data);
            linkedList.AddFirst(item1_data);

            #endregion Arrange

            #region Act

            var data = linkedList[index];

            #endregion Act

            #region Assert

            data.Should().NotBeNullOrWhiteSpace();
            data.Should().Be($"item{index + 1}_data");

            #endregion Assert
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void ShouldBeSuccess___Indexer___Set(int index)
        {
            #region Arrange

            var linkedList = new LinkedList<string>();
            var item1_data = "item1_data";
            var item2_data = "item2_data";
            linkedList.AddFirst(item2_data);
            linkedList.AddFirst(item1_data);

            #endregion Arrange

            #region Act

            var newData = $"item{index + 2}_data";
            linkedList[index] = newData;
            var data = linkedList[index];

            #endregion Act

            #region Assert

            data.Should().NotBeNullOrWhiteSpace();
            data.Should().Be(newData);

            #endregion Assert
        }

        [Theory]
        [InlineData("item1_data")]
        [InlineData("item2_data")]
        public void ShouldBeSuccess___Find(string data)
        {
            #region Arrange

            var linkedList = new LinkedList<string>();
            var item1_data = "item1_data";
            var item2_data = "item2_data";
            linkedList.AddFirst(item2_data);
            linkedList.AddFirst(item1_data);

            #endregion Arrange

            #region Act

            var node = linkedList.Find(data);

            #endregion Act

            #region Assert

            node.Should().NotBeNull();
            var expectedNodeData = data;
            var expectedNodeNext = (LinkedListNode<string>)null;
            if (data.Equals(item1_data))
            {
                expectedNodeNext = new LinkedListNode<string>(item2_data, null);
            }
            var expectedNode = new LinkedListNode<string>(expectedNodeData, expectedNodeNext);
            node.Should().BeEquivalentTo(expectedNode);

            #endregion Assert
        }

        #endregion Tests
    }
}