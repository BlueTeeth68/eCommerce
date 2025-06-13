package exception;

public class DataAlreadyExistException extends RuntimeException {
    public DataAlreadyExistException(String message) {
        super(message);
    }

    public DataAlreadyExistException() {
        super("Data Already Exist");
    }
}
