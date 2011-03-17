 
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.utility;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class VisitorExtensionsSpecs
    {
        public abstract class concern : Observes
        {

        }

        [Subject(typeof(VisitorExtensions))]
        public class when_visiting_all_of_the_items_in_an_iterator_with_a_visitor : concern
        {
            Establish c = () =>
            {
                all_items = Enumerable.Range(1, 100).ToList();
                visitor = an<Visitor<int>>();
            };

            Because b = () =>
                VisitorExtensions.visit_all_items_using(all_items, visitor);


            It should_process_each_item_through_the_visitor = () =>
                all_items.each(x => visitor.received(y => y.process(x)));

            static IEnumerable<int> all_items;
            static Visitor<int> visitor;
        }

        public class when_getting_the_result_of_visiting_a_set_of_items_with_a_visitor : concern
        {
            Establish c = () =>
            {
                all_items = Enumerable.Range(1, 100).ToList();
                visitor = an<ValueReturningVisitor<int, int>>();

                visitor.setup(x => x.get_result()).Return(42);
            };

            Because b = () =>
                result = VisitorExtensions.get_the_result_of_visiting_all_items_with(all_items, visitor);

            It should_visit_all_of_the_items = () =>
                visitor.received(x => x.process(Arg<int>.Is.Anything)).Times(100);
  
            It should_return_the_result_of_the_visitor = () =>
                result.ShouldEqual(42);


            static IEnumerable<int> all_items;
            static ValueReturningVisitor<int,int> visitor;
            static int result;
        }
    }
}
