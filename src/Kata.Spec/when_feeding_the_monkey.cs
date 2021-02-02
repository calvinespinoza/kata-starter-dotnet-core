using System;
using FluentAssertions;
using Machine.Specifications;

namespace Kata.Spec
{
    public class when_feeding_the_monkey
    {
        static Monkey _systemUnderTest;

        Establish context = () =>
            _systemUnderTest = new Monkey();

        Because of = () =>
            _systemUnderTest.Eat("banana");

        It should_have_the_food_in_its_belly = () =>
            _systemUnderTest.Belly.Should().Contain("banana");
    }

    public class when_calculating_with_empty_input
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add(); };

        It should_return_zero = () => { _result.Should().Be(0); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_input_has_one_number
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };
        Because of = () => { _result = _systemUnderTest.Add("3"); };
        It should_return_same_number = () => { _result.Should().Be(3); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_is_two_numbers
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("1,4"); };

        It should_return_the_sum_of_both = () => { _result.Should().Be(5); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_input_has_multiple_numbers
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };
        Because of = () => { _result = _systemUnderTest.Add("1,2,3"); };
        It should_return_sum_of_all_numbers = () => { _result.Should().Be(6); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_includes_a_new_line_delimiter
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("1,2\n3"); };

        It should_return_the_sum_all_numbers = () => { _result.Should().Be(6); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_input_has_custom_delimiter
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };
        Because of = () => { _result = _systemUnderTest.Add("//;\n1;2"); };
        It should_return_sum = () => { _result.Should().Be(3); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_calculating_the_sum_with_one_negative_number
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("1,-2,3")); };

        It should_throw_an_error_with_the_number = () => { _result.Message.Should().Be("negatives not allowed: -2"); };
        static Exception _result;
        static Calculator _systemUnderTest;
    }

    public class when_input_contains_multiple_numbers
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };
        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("-1, 2, -3")); };
        It should_throw_error_with_numbers = () => { _result.Message.Should().Be("negatives not allowed: -1, -3"); };
        static Calculator _systemUnderTest;
        static Exception _result;
    }

    public class when_adding_numbers_with_some_above_1000
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("1,2,1001"); };

        It should_ignore_numbers_larger_than_1000 = () => { _result.Should().Be(3); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_input_has_custom_multicharacter_delimiter
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };
        Because of = () => { _result = _systemUnderTest.Add("//[***]\n12***3"); };
        It should_return_the_sum = () => { _result.Should().Be(15); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_summing_with_multiple_multiple_char_delimiters
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Add("//[***][%]\n1***2%3"); };

        It should_return_the_sum = () => { _result.Should().Be(6); };
        static Calculator _systemUnderTest;
        static int _result;
    }
    // Given the user input is multiple numbers with multiple custom delimiters when calculating the sum then it should return the sum of all the numbers. (example “//[][%]\n12%3” should return 6)
}