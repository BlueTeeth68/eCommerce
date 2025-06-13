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
import reactor.core.publisher.Mono;

import java.time.Instant;

@ControllerAdvice
public class GlobalExceptionController {

    /**
     * Handles exceptions of type {@code ForbiddenException} and constructs a custom
     * response entity containing error details.
     *
     * @param ex the {@code ForbiddenException} that was thrown
     * @param request the current {@code NativeWebRequest} in which the exception occurred
     * @return a {@code ResponseEntity} containing error details with an HTTP status of 403 (Forbidden)
     */
    @ExceptionHandler({ForbiddenException.class})
    public Mono<ApiResponse<Object>> handleAccessDeniedException(
            ForbiddenException ex, NativeWebRequest request) {
        ErrorResponse error = ErrorResponse.builder()
                .title("Access denied")
                .timestamp(Instant.now())
                .detail(ex.getMessage())
                .status(HttpStatus.FORBIDDEN)
                .type(request.getContextPath())
                .build();
        return Mono.just(ApiResponse.builder()
                .success(false)
                .error(error)
                .build());
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
    public Mono<ApiResponse<Object>> handleDataAlreadyExistsException(
            RuntimeException ex, NativeWebRequest request) {
        ErrorResponse error = ErrorResponse.builder()
                .title("Data already exist")
                .type(request.getContextPath())
                .timestamp(Instant.now())
                .detail(ex.getMessage())
                .status(HttpStatus.CONFLICT)
                .build();
        return Mono.just(ApiResponse.builder()
                .success(false)
                .error(error)
                .build());
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
    public Mono<ApiResponse<Object>> handleBadRequestException(
            RuntimeException ex, NativeWebRequest request) {
        ErrorResponse error = ErrorResponse.builder()
                .title("Bad request")
                .type(request.getContextPath())
                .timestamp(Instant.now())
                .detail(ex.getMessage())
                .status(HttpStatus.BAD_REQUEST)
                .build();

        return Mono.just(ApiResponse.builder()
                .success(false)
                .error(error)
                .build());
    }

    /**
     * Handles exceptions of type {@code UnauthorizeException} and generates a standardized
     * error response with detailed information about the unauthorized request.
     *
     * @param ex the exception thrown when an unauthorized access attempt is detected
     * @param request the web request during which the exception*/
    @ExceptionHandler({UnauthorizeException.class})
    public Mono<ApiResponse<Object>> handleAuthenticationException(
            RuntimeException ex, NativeWebRequest request) {
        ErrorResponse error = ErrorResponse.builder()
                .title("Unauthorize")
                .type(request.getContextPath())
                .timestamp(Instant.now())
                .detail(ex.getMessage())
                .status(HttpStatus.UNAUTHORIZED)
                .build();

        return Mono.just(ApiResponse.builder()
                .success(false)
                .error(error)
                .build());
    }
}
