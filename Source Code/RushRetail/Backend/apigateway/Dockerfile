FROM maven:3.9-eclipse-temurin-21-alpine AS build

WORKDIR /app
COPY . .
RUN mvn clean package -DskipTests

FROM eclipse-temurin:21-jre-alpine

WORKDIR /app
COPY --from=build /app/gateway/target/*.jar app.jar

EXPOSE 8008

ENTRYPOINT ["java", "-jar", "app.jar"]