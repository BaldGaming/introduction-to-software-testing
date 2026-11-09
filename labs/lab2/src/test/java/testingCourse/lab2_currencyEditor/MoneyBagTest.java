package testingCourse.lab2_currencyEditor;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.Test;

public class MoneyBagTest {

    // Define classes for tests
    private Money m10usd;
    private Money m5usd;
    private Money m0usd;
    private Money mn0usd;
    private Money mn10usd;

    @BeforeEach
    void setUp() {
        m10usd= new Money(10,"USD");
        m5usd = new Money(5, "USD");
        m0usd = new Money(0, "USD");
        mn0usd = new Money(-0, "USD");
        mn10usd = new Money(-10, "USD");
    }

    @AfterEach
    void tearDown() {
        
    }

    @Test
    void testAdd() {

    }

    @Test
    void testContains() {

    }
}
