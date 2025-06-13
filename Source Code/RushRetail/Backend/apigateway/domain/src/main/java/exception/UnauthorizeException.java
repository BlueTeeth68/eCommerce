package exception;

public class UnauthorizeException extends RuntimeException {
    public UnauthorizeException(String message) {
        super(message);
    }

    public UnauthorizeException() {
        super("Unauthorize");
    }
}
