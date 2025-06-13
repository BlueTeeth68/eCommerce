package com.rustretail.gateway.controller;

import com.rustretail.gateway.controller.model.ApiResponse;
import com.rustretail.gateway.controller.model.ErrorResponse;
import exception.BadRequestException;
import exception.DataAlreadyExistException;
import exception.ForbiddenException;
import exception.UnauthorizeException;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.context.request.NativeWebRequest;
import org.springframework.web.servlet.mvc.method.annotation.ResponseEntityExceptionHandler;

import java.time.Instant;

/**
 * This class serves as a global exception handler for handling and customizing the response for
 * various exceptions thrown by the application. It extends {@link ResponseEntityExceptionHandler}
 * to leverage its capabilities and provides custom handling for specific exception types.
 *
 * The class is annotated with {@code @ControllerAdvice} to define global exception handling
 * behavior for all controllers in the application.
 *
 * Each exception handler method returns a {@link ResponseEntity} containing an {@link ErrorResponse}
 * object with appropriate details for the error.
 *
 * Exception types handled in this class:
 * 1. {@code ForbiddenException} - Access denied errors.
 * 2. {@code DataAlreadyExistException} - Conflicting data already exists errors.
 * 3. {@code BadRequestException} - Bad request errors.
 * 4. {@code UnauthorizeException} - Unauthorized access errors.
 *
 * The {@link ErrorResponse} encapsulates the error details such as title, timestamp, status code,
 * and a descriptive message.
 */
@ControllerAdvice
public class GlobalExceptionController extends ResponseEntityExceptionHandler {

    /**
     * Handles exceptions of type {@code ForbiddenException} and constructs a custom
     * response entity containing error details.
     *
     * @param ex the {@code ForbiddenException} that was thrown
     * @param request the current {@code NativeWebRequest} in which the exception occurred
     * @return a {@code ResponseEntity} containing error details with an HTTP status of 403 (Forbidden)
     */
    @ExceptionHandler({ForbiddenException.class})
    public ApiResponse<Object> handleAccessDeniedException(
            ForbiddenException ex, NativeWebRequest request) {
        ErrorResponse error = ErrorResponse.builder()
                .title("Access denied")
                .timestamp(Instant.now())
                .detail("You don't have permission to access this resource")
                .status(HttpStatus.FORBIDDEN)
                .build();
        return ApiResponse.builder()
                .success(false)
                .error(error)
                .build();
    }

    /**
     * Handles exceptions of type {@link DataAlreadyExistException} and provides a structured
     * response containing the error details.
     *
     * @param ex the exception object representing the error
     * @param request the current web request during which the exception occurred
     * @return a {@link ResponseEntity} containing an {@code ErrorResponse} object with details about the error,
     *         including a "Data already exist" message and an HTTP status code of {@link HttpStatus#CONFLICT}
     */
    @ExceptionHandler({DataAlreadyExistException.class})
    public ApiResponse<Object> handleDataAlreadyExistsException(
            RuntimeException ex, NativeWebRequest request) {
        ErrorResponse error = ErrorResponse.builder()
                .title("Data already exist")
                .timestamp(Instant.now())
                .detail(ex.getMessage())
                .status(HttpStatus.CONFLICT)
                .build();
        return ApiResponse.builder()
                .success(false)
                .error(error)
                .build();
    }

    /**
     * Handles exceptions of type {@code BadRequestException}.
     * Constructs an {@code ErrorResponse} containing details about the bad request
     * and returns it in the form of a {@code ResponseEntity}.
     *
     * @param ex the {@code RuntimeException} instance that triggered this handler
     * @param request the {@code NativeWebRequest} related to the exception occurrence
     * @return a {@code ResponseEntity} containing an*/
    @ExceptionHandler({BadRequestException.class})
    public ApiResponse<Object> handleBadRequestException(
            RuntimeException ex, NativeWebRequest request) {
        ErrorResponse error = ErrorResponse.builder()
                .title("Bad request")
                .timestamp(Instant.now())
                .detail(ex.getMessage())
                .status(HttpStatus.BAD_REQUEST)
                .build();

        return ApiResponse.builder()
                .success(false)
                .error(error)
                .build();
    }

    /**
     * Handles exceptions of type {@code UnauthorizeException} and generates a standardized
     * error response with detailed information about the unauthorized request.
     *
     * @param ex the exception thrown when an unauthorized access attempt is detected
     * @param request the web request during which the exception*/
    @ExceptionHandler({UnauthorizeException.class})
    public ApiResponse<Object> handleAuthenticationException(
            RuntimeException ex, NativeWebRequest request) {
        ErrorResponse error = ErrorResponse.builder()
                .title("Unauthorize")
                .timestamp(Instant.now())
                .detail(ex.getMessage())
                .status(HttpStatus.UNAUTHORIZED)
                .build();

        return ApiResponse.builder()
                .success(false)
                .error(error)
                .build();
    }
}
