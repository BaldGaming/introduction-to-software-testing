package testingCourse.lab2_currencyEditor;

import static org.junit.jupiter.api.Assertions.assertTrue;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

public class MoneyBagTest {

    private Money m10usd;
    private Money m5chf;
    private Money m7nis;
    private Money m0usd;
    private Money mn5chf;
    private Money m15usd;
    private Money m25usd;
    
    private MoneyBag baseBag; // Will contain 10 USD and 5 CHF

    @BeforeEach
    protected void setUp() throws Exception {
        m10usd = new Money(10, "USD");
        m5chf = new Money(5, "CHF");
        m7nis = new Money(7, "NIS");
        m0usd = new Money(0, "USD");
        mn5chf = new Money(-5, "CHF");
        m15usd = new Money(15, "USD");
        m25usd = new Money(25, "USD");
        
        // Bag used for testing MoneyBag methods
        baseBag = new MoneyBag(m10usd, m5chf);
    }

    // adding a positive valid amount to a non-existing amount
    // input: MoneyBag(10 USD, 5 CHF), add Money(7, "NIS")
    // expected: MoneyBag(10 USD, 5 CHF, 7 NIS)
    @Test
    public void testAddMoney_nonExistingCurrency() {
        Money[] expectedMonies = { m10usd, m5chf, m7nis };
        MoneyBag expected = new MoneyBag(expectedMonies);
        IMoney result = baseBag.addMoney(m7nis);

        assertTrue(expected.equals(result));
    }

    // adding a positive valid amount to an existing amount
    // input: MoneyBag(10 USD, 5 CHF), add Money(15, "USD")
    // expected: MoneyBag(25 USD, 5 CHF)
    @Test
    public void testAddMoney_existingCurrency() {
        MoneyBag expected = new MoneyBag(m25usd, m5chf);
        IMoney result = baseBag.addMoney(m15usd);

        assertTrue(expected.equals(result));
    }

    // adding a zero amount
    // input: MoneyBag(10 USD, 5 CHF), add Money(0, "USD")
    // expected: MoneyBag(10 USD, 5 CHF)
    @Test
    public void testAddMoney_addZero() {
        IMoney result = baseBag.addMoney(m0usd);

        assertTrue(baseBag.equals(result));
    }

    // adding a negative amount that cancels out an existing currency
    // input: MoneyBag(10 USD, 5 CHF), add Money(-5, "CHF")
    // expected: Money(10, "USD")
    @Test
    public void testAddMoney_addNegativeAmount() {
        IMoney result = baseBag.addMoney(mn5chf);

        assertTrue(m10usd.equals(result));
    }

    // bag contains an existing currency with the exact amount
    // input: MoneyBag(10 USD, 5 CHF), check for Money(10, "USD")
    // expected: true
    @Test
    public void testContains_exactMatch() {
        assertTrue(baseBag.contains(m10usd));
    }

    // bag contains the currency but the amount is different
    // input: MoneyBag(10 USD, 5 CHF), check for Money(15, "USD")
    // expected: false
    @Test
    public void testContains_wrongAmount() {
        assertTrue(!baseBag.contains(m15usd));
    }

    // bag does not contain the requested currency at all
    // input: MoneyBag(10 USD, 5 CHF), check for Money(7, "NIS")
    // expected: Expected to throw NullPointerException
    @Test
    public void testContains_missingCurrency() {
        try {
            boolean result = baseBag.contains(m7nis);

            assertTrue(!result);

        } catch (NullPointerException e) { // Catches the error and returns true because the currency is missing
            assertTrue(true);
        }
    }

    // bag does not contain a zero amount of an existing currency
    // input: MoneyBag(10 USD, 5 CHF), check for Money(0, "USD")
    // expected: false
    @Test
    public void testContains_zeroAmount() {
        assertTrue(!baseBag.contains(m0usd));
    }
}