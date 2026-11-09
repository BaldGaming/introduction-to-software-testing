package testingCourse.lab2_currencyEditor;

import org.junit.jupiter.api.BeforeEach;

import static org.junit.jupiter.api.Assertions.assertTrue;

import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.Test;

public class MoneyBagTest {

    // Define classes for tests
    private Money m10usd;
    private Money m5chf;
    private Money m0usd;
    private Money mn0chf;
    private Money mn10chf;

    @BeforeEach

    void setUp() {
        m10usd= new Money(10,"USD");
        m5chf = new Money(5, "CHF");
        m0usd = new Money(0, "USD");
        mn0chf = new Money(-0, "CHF");
        mn10chf = new Money(-10, "CHF");
    }

    // Test for adding a positive valid amount to a non-existing amount
    @Test
    void testAddNonExist() {
        MoneyBag expected= new MoneyBag(m5chf, m10usd);
		MoneyBag result= (MoneyBag)m10usd.add(m5chf);
		assertTrue(expected.equals(result));
    }

    // Test for adding a positive valid amount to an existing amount
    @Test
    void testAddZero() {
        MoneyBag expected = new MoneyBag(m10usd, m5chf);
        MoneyBag result = (MoneyBag)m0usd.addMoneyBag(expected);
        assertTrue(expected.equals(result));
    }
    
    // Test for subtracting a valid amount to a non-existing amount
    @Test
    void testSubtractNonExist() {
        Money expected = new Money(m5chf);
        MoneyBag result = (MoneyBag)m0usd.addMoneyBag(expected);
        assertTrue(expected.equals(result));
    }

    // Test for 
    @Test
    void temp3() {

    }

    // Test for 
    @Test
    void temp4() {

    }

    // Test for 
    @Test
    void temp5() {

    }

    // Test for 
    @Test
    void temp6() {

    }

    // Test for 
    @Test
    void temp7() {

    }
}
