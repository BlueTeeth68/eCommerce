package exception;

public class ValidateException extends RuntimeException {
    public ValidateException(String message) {
        super(message);
    }

    public ValidateException() {
        super("Validation Failed");
    }
}
