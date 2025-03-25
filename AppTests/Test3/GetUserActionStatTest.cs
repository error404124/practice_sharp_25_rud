using App.Practice3;

namespace AppTests.Test3;

public class GetUserActionStatTest
{
    [Test]
    public void GetUserActionStatTest1()
    {
        var request = new UserActionStatRequest
        {
            StartDate = new DateTime(2024, 12, 10),
            EndDate = new DateTime(2025, 1, 30),
            DateGroupType = DateGroupTypes.Daily
        };

        var userActionItems = new List<UserActionItem>
        {
            new UserActionItem { Date = new DateTime(2024, 12, 9), Action = ActionTypes.Login, Count = 1 },
            new UserActionItem { Date = new DateTime(2024, 12, 10), Action = ActionTypes.SearchProducts, Count = 3 },
            new UserActionItem
                { Date = new DateTime(2024, 12, 10), Action = ActionTypes.GetProductDetails, Count = 12 },
            new UserActionItem { Date = new DateTime(2024, 12, 10), Action = ActionTypes.AddProductToCart, Count = 2 },
            new UserActionItem { Date = new DateTime(2025, 1, 1), Action = ActionTypes.PayOrder, Count = 1 },
            new UserActionItem { Date = new DateTime(2025, 1, 15), Action = ActionTypes.RecieveOrder, Count = 1 }
        };

        var result = new UserSatProvider().GetUserActionStat(request, userActionItems);

        var expected = new List<UserActionStatItem>
        {
            new UserActionStatItem
            {
                StartDate = new DateTime(2024, 12, 10),
                EndDate = new DateTime(2024, 12, 10),
                ActionMetrics = new Dictionary<ActionTypes, int>
                {
                    { ActionTypes.SearchProducts, 3 },
                    { ActionTypes.GetProductDetails, 12 },
                    { ActionTypes.AddProductToCart, 2 }
                }
            },
            new UserActionStatItem
            {
                StartDate = new DateTime(2025, 1, 1),
                EndDate = new DateTime(2025, 1, 1),
                ActionMetrics = new Dictionary<ActionTypes, int>
                {
                    { ActionTypes.PayOrder, 1 }
                }
            },
            new UserActionStatItem
            {
                StartDate = new DateTime(2025, 1, 15),
                EndDate = new DateTime(2025, 1, 15),
                ActionMetrics = new Dictionary<ActionTypes, int>
                {
                    { ActionTypes.RecieveOrder, 1 }
                }
            }
        };

        Assert.That(result.UserActionStat.Count, Is.EqualTo(expected.Count));
        for (var i = 0; i < expected.Count; i++)
        {
            var actualItem = result.UserActionStat[i];
            var expectedItem = expected[i];

            Assert.That(actualItem.StartDate, Is.EqualTo(expectedItem.StartDate));
            Assert.That(actualItem.EndDate, Is.EqualTo(expectedItem.EndDate));
            Assert.That(actualItem.ActionMetrics.Count, Is.EqualTo(expectedItem.ActionMetrics.Count));

            foreach (var action in expectedItem.ActionMetrics)
            {
                Assert.That(actualItem.ActionMetrics.ContainsKey(action.Key), Is.True);
                Assert.That(actualItem.ActionMetrics[action.Key], Is.EqualTo(action.Value));
            }
        }
    }

    [Test]
    public void GetUserActionStatTest2()
    {
        var request = new UserActionStatRequest
        {
            StartDate = new DateTime(2024, 12, 9),
            EndDate = new DateTime(2025, 1, 14),
            DateGroupType = DateGroupTypes.Monthly
        };

        var userActionItems = new List<UserActionItem>
        {
            new UserActionItem { Date = new DateTime(2024, 12, 9), Action = ActionTypes.Login, Count = 1 },
            new UserActionItem { Date = new DateTime(2024, 12, 10), Action = ActionTypes.SearchProducts, Count = 3 },
            new UserActionItem
                { Date = new DateTime(2024, 12, 10), Action = ActionTypes.GetProductDetails, Count = 12 },
            new UserActionItem { Date = new DateTime(2024, 12, 10), Action = ActionTypes.AddProductToCart, Count = 2 },
            new UserActionItem { Date = new DateTime(2025, 1, 1), Action = ActionTypes.PayOrder, Count = 1 }
        };

        var result = new UserSatProvider().GetUserActionStat(request, userActionItems);

        var expected = new List<UserActionStatItem>
        {
            new UserActionStatItem
            {
                StartDate = new DateTime(2024, 12, 1),
                EndDate = new DateTime(2024, 12, 31),
                ActionMetrics = new Dictionary<ActionTypes, int>
                {
                    { ActionTypes.Login, 1 },
                    { ActionTypes.SearchProducts, 3 },
                    { ActionTypes.GetProductDetails, 12 },
                    { ActionTypes.AddProductToCart, 2 }
                }
            },
            new UserActionStatItem
            {
                StartDate = new DateTime(2025, 1, 1),
                EndDate = new DateTime(2025, 1, 14), 
                ActionMetrics = new Dictionary<ActionTypes, int>
                {
                    { ActionTypes.PayOrder, 1 }
                }
            }
        };

        Assert.That(result.UserActionStat.Count, Is.EqualTo(expected.Count));
        for (var i = 0; i < expected.Count; i++)
        {
            var actualItem = result.UserActionStat[i];
            var expectedItem = expected[i];
            
            Assert.That(actualItem.StartDate, Is.EqualTo(expectedItem.StartDate));
            Assert.That(actualItem.EndDate, Is.EqualTo(expectedItem.EndDate));
            Assert.That(actualItem.ActionMetrics.Count, Is.EqualTo(expectedItem.ActionMetrics.Count));
            
            foreach (var action in expectedItem.ActionMetrics)
            {
                Assert.That(actualItem.ActionMetrics.ContainsKey(action.Key), Is.True);
                Assert.That(actualItem.ActionMetrics[action.Key], Is.EqualTo(action.Value));
            }
        }
    }
}