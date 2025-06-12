package com.rustretail.gateway.controller.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.*;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Builder
public class ValidateInfo {
    @JsonProperty("field")
    private String field;
    @JsonProperty("description")
    private String description;
}
