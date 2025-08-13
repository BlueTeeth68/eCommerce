package com.rustretail.api.controller.auth;

import com.rustretail.api.config.JwtService;
import com.rustretail.application.user.UserApplicationService;
import entities.enums.Role;
import io.swagger.v3.oas.annotations.Operation;
import jakarta.validation.Valid;
import jakarta.validation.constraints.Email;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.Size;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.BadCredentialsException;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.HashMap;
import java.util.Map;

@RestController
@RequestMapping("/api/auth")
public class AuthController {
    private final AuthenticationManager authenticationManager;
    private final JwtService jwtService;
    private final UserApplicationService userService;

    public AuthController(AuthenticationManager authenticationManager, JwtService jwtService, UserApplicationService userService) {
        this.authenticationManager = authenticationManager;
        this.jwtService = jwtService;
        this.userService = userService;
    }

    public record LoginRequest(
            @NotBlank @Email String username,
            @NotBlank @Size(min = 6, max = 100) String password
    ) {}

    public record RegisterRequest(
            @NotBlank @Email String email,
            @NotBlank @Size(min = 6, max = 100) String password,
            Role role
    ) {}

    public record RefreshRequest(@NotBlank String refreshToken) {}

    @Operation(summary = "Authenticate and get access/refresh tokens")
    @PostMapping("/login")
    public ResponseEntity<?> login(@Valid @RequestBody LoginRequest request) {
        try {
            Authentication authentication = authenticationManager.authenticate(
                    new UsernamePasswordAuthenticationToken(request.username(), request.password())
            );
            UserDetails user = (UserDetails) authentication.getPrincipal();
            String accessToken = jwtService.generateAccessToken(user.getUsername(), new HashMap<>());
            String refreshToken = jwtService.generateRefreshToken(user.getUsername(), new HashMap<>());
            Map<String, Object> body = new HashMap<>();
            body.put("tokenType", "Bearer");
            body.put("accessToken", accessToken);
            body.put("refreshToken", refreshToken);
            body.put("username", user.getUsername());
            return ResponseEntity.ok(body);
        } catch (BadCredentialsException ex) {
            throw ex; // handled by global exception handler
        }
    }

    @Operation(summary = "Register a new user and get tokens")
    @PostMapping("/register")
    public ResponseEntity<?> register(@Valid @RequestBody RegisterRequest request) {
        var user = userService.register(request.email(), request.password(), request.role());
        String accessToken = jwtService.generateAccessToken(user.getEmail(), new HashMap<>());
        String refreshToken = jwtService.generateRefreshToken(user.getEmail(), new HashMap<>());
        Map<String, Object> body = new HashMap<>();
        body.put("tokenType", "Bearer");
        body.put("accessToken", accessToken);
        body.put("refreshToken", refreshToken);
        body.put("username", user.getEmail());
        return ResponseEntity.ok(body);
    }

    @Operation(summary = "Use refresh token to obtain a new access token")
    @PostMapping("/refresh")
    public ResponseEntity<?> refresh(@Valid @RequestBody RefreshRequest request) {
        String token = request.refreshToken();
        String username = jwtService.extractUsername(token);
        if (username == null || !jwtService.isRefreshTokenValid(token, username)) {
            throw new BadCredentialsException("Invalid refresh token");
        }
        String newAccess = jwtService.generateAccessToken(username, new HashMap<>());
        Map<String, Object> body = new HashMap<>();
        body.put("tokenType", "Bearer");
        body.put("accessToken", newAccess);
        body.put("username", username);
        return ResponseEntity.ok(body);
    }
}
