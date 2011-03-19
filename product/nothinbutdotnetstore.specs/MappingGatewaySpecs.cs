using System;
using developwithpassion.specifications.rhino;
using Machine.Specifications;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.web.core;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    public class MappingGatewaySpecs
    {
        public abstract class concern : Observes<MappingGateway,
                                            DefaultMappingGateway>
        {
        }

        [Subject(typeof(DefaultMappingGateway))]
        public class when_mapping_an_input_to_an_output : concern
        {
            Establish c = () =>
            {
                the_mapper = an<Mapper<string, int>>();
                container = the_dependency<DependencyContainer>();
                container.setup(x => x.an<Mapper<string,int>>()).Return(the_mapper);
                the_mapper.setup(x => x.map(input_value)).Return(23);
            };

            Because b = () =>
                result = sut.map<string, int>(input_value);

            It should_return_the_item_mapped_using_the_mapper_for_the_mapping_pair = () =>
                result.ShouldEqual(23);

            static int result;
            static DependencyContainer container;
            static Mapper<string,int> the_mapper;
            const string input_value = "sdfsdf";
        }
    }
}