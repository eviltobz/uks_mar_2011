using System.Collections.Generic;

namespace nothinbutdotnetstore.utility
{
    public static class VisitorExtensions
    {
        public static void visit_all_items_using<ItemToVisit>(this IEnumerable<ItemToVisit> all_items,
                                                              Visitor<ItemToVisit> visitor)
        {
            foreach (var item_to_visit in all_items) visitor.process(item_to_visit);
        }

        public static ReturnType get_the_result_of_visiting_all_items_with<ItemToVisit, ReturnType>(
            this IEnumerable<ItemToVisit> all_items, ValueReturningVisitor<ItemToVisit, ReturnType> visitor)
        {
            all_items.visit_all_items_using(visitor);
            return visitor.get_result();
        }
    }
}