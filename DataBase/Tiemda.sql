-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema Tiemda
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS Tiemda ;
-- -----------------------------------------------------
-- Schema Tiemda
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Tiemda` DEFAULT CHARACTER SET utf8 ;
USE `Tiemda` ;

-- -----------------------------------------------------
-- Table `Tiemda`.`Articulos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Tiemda`.`Articulos` (
  `ID` VARCHAR(15) NOT NULL,
  `Tipo` ENUM('Hamburguesa', 'Pizza', 'Bebida') NOT NULL,
  `Nombre` VARCHAR(45) NOT NULL,
  `Costo` DECIMAL(10,2) NOT NULL,
  `Descripccion` VARCHAR(255) NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Tiemda`.`Ventas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Tiemda`.`Ventas` (
  `idVentas` VARCHAR(15) NOT NULL,
  `fecha` VARCHAR(45) NOT NULL,
  `total` DECIMAL(10,2) NOT NULL,
  `Descripcion` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`idVentas`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Tiemda`.`Detalles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Tiemda`.`Detalles` (
  `idVenta` VARCHAR(15) NOT NULL,
  `Producto` VARCHAR(45) NOT NULL,
  `Tipo` ENUM('Hamburguesa', 'Pizza', 'Bebida') NOT NULL,
  `Cantidad` INT NOT NULL,
  `Total` DECIMAL(10,2) NOT NULL,
  INDEX `idVenta_idx` (`idVenta` ASC) VISIBLE,
  PRIMARY KEY (`Producto`),
  CONSTRAINT `idVenta`
    FOREIGN KEY (`idVenta`)
    REFERENCES `Tiemda`.`Ventas` (`idVentas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Tiemda`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Tiemda`.`Usuario` (
  `idUsuario` VARCHAR(15) NOT NULL,
  `Nombre` VARCHAR(45) NOT NULL,
  `Primer_Apellido` VARCHAR(45) NOT NULL,
  `Segundo_Apellido` VARCHAR(45) NOT NULL,
  `Contraseña` VARCHAR(45) NOT NULL,
  `Correo` VARCHAR(45) NOT NULL,
  `Tipo` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idUsuario`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

use tiemda;
