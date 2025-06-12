package com.rustretail.gateway.controller.model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.*;
import lombok.experimental.SuperBuilder;
import org.springframework.http.HttpStatus;

import java.io.Serializable;
import java.time.Instant;
import java.util.List;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Builder
@JsonIgnoreProperties(ignoreUnknown = true)
@JsonInclude(JsonInclude.Include.NON_NULL)
public class ErrorResponse implements Serializable {
    @JsonProperty("code")
    private String type;
    @JsonProperty("status")
    private HttpStatus status;
    @JsonProperty("title")
    private String title;
    @JsonProperty("detail")
    private String detail;
    @JsonProperty("date")
    private Instant date = Instant.now();

    @JsonProperty("errors")
    private List<ErrorDetail> errorDetails;
}
