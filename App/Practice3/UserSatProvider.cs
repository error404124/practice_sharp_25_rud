namespace App.Practice3;

public class UserSatProvider
{
    public static List<UserActionItem> FilteredGroupTypeByData(
        UserActionStatRequest request, List<UserActionItem> userActionItems)
    {
        var startDate = request.StartDate;
        var endDate = request.EndDate;
        var filteredUserActionItems = new List<UserActionItem>();
        foreach (var userActionItem in userActionItems)
        {
            if (userActionItem.Date >= startDate && userActionItem.Date <= endDate)
            {
                filteredUserActionItems.Add(userActionItem);
            }
        }

        return filteredUserActionItems;
    }

    public static DateTime FindPeriodKey(UserActionStatRequest request, UserActionItem userActionItem)
    {
        if (request.DateGroupType == DateGroupTypes.Daily)
        {
            return userActionItem.Date.Date;
        }

        return new DateTime(userActionItem.Date.Year, userActionItem.Date.Month, 1);
    }

    public static void AddToDictionary(
        UserActionItem userActionItem,
        DateTime periodKey,
        Dictionary<DateTime, Dictionary<ActionTypes, int>> actionDict)
    {
        if (!actionDict.ContainsKey(periodKey))
        {
            actionDict[periodKey] = new Dictionary<ActionTypes, int>();
        }

        actionDict[periodKey].TryAdd(userActionItem.Action, 0);
        actionDict[periodKey][userActionItem.Action] += userActionItem.Count;
    }

    public static Dictionary<DateTime, Dictionary<ActionTypes, int>> GroupActionItems(UserActionStatRequest request,
        List<UserActionItem> userActionItems)
    {
        var filteredUserActionItems = FilteredGroupTypeByData(request, userActionItems);

        var selectedDict = new Dictionary<DateTime, Dictionary<ActionTypes, int>>();
        foreach (var userActionItem in filteredUserActionItems)
        {
            var periodKey = FindPeriodKey(request, userActionItem);

            AddToDictionary(userActionItem, periodKey, selectedDict);
        }

        return selectedDict;
    }

    public static UserActionStatItem CreateStatItem(KeyValuePair<DateTime, Dictionary<ActionTypes, int>> entry,
        UserActionStatRequest request)
    {
        var statItem = new UserActionStatItem();
        statItem.StartDate = entry.Key;

        if (request.DateGroupType == DateGroupTypes.Daily)
        {
            statItem.EndDate = entry.Key;
        }

        else
        {
            if (request.EndDate.Month == entry.Key.Month)
                statItem.EndDate = request.EndDate;
            else
            {
                var tmp = new DateTime(entry.Key.Year, entry.Key.Month, 1);
                var lastDay = tmp.AddMonths(1).AddDays(-1);
                statItem.EndDate = lastDay;
            }
        }

        statItem.ActionMetrics = entry.Value;

        return statItem;
    }


    public UserActionStatResponse GetUserActionStat(UserActionStatRequest request, List<UserActionItem> userActionItems)
    {
        var selectedDict = GroupActionItems(request, userActionItems);
        var userActionStatItems = new List<UserActionStatItem>();

        foreach (var entry in selectedDict)
        {
            var statItem = CreateStatItem(entry, request);
            userActionStatItems.Add(statItem);
        }

        return new UserActionStatResponse { UserActionStat = userActionStatItems };
    }
}