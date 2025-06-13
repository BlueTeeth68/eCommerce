package com.rustretail.gateway.controller.model;

import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.*;

import java.io.Serializable;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Builder
@JsonInclude(JsonInclude.Include.NON_NULL)
public class ApiResponse<T> implements Serializable {
    @JsonProperty("data")
    private T data;
    @JsonProperty("isSuccess")
    private Boolean success;

    @JsonProperty("error")
    private ErrorResponse error;
}
