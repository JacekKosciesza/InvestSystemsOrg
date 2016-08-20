import {Injectable} from '@angular/core';

import Logger from "log4ts/build/Logger"
import LoggerConfig from "log4ts/build/LoggerConfig"
import BasicLayout from "log4ts/build/layouts/BasicLayout";
import ConsoleAppender from "log4ts/build/appenders/ConsoleAppender";
import {IAppender} from "log4ts/build/IAppender";
import {ILayout} from "log4ts/build/ILayout";
import {LogLevel} from "log4ts/build/LogLevel";

@Injectable()
export class LogService {

    public logger: Logger;

    private appender: IAppender;
    private layout: ILayout;
    private config: LoggerConfig;

    constructor() {
        this.layout = new BasicLayout();
        this.appender = new ConsoleAppender();
        this.appender.setLayout(this.layout);
        this.config = new LoggerConfig(this.appender);
        this.config.setLevel(LogLevel.ALL);
        this.logger = new Logger(''); // TODO: tag?
        Logger.setConfig(this.config);
    }

    log(message: string, object?: any, deep?: number) {
        this.logger.log(message, object, deep);
    }

    trace(message: string, object?: any, deep?: number) {
        this.logger.trace(message, object, deep);
    }

    debug(message: string, object?: any, deep?: number) {
        this.logger.debug(message, object, deep);
    }

    info(message: string, object?: any, deep?: number) {
        this.logger.info(message, object, deep);
    }

    warn(message: string, object?: any, deep?: number) {
        this.logger.warn(message, object, deep);
    }

    error(message: string, object?: any, deep?: number) {
        this.logger.error(message, object, deep);
    }

    fatal(message: string, object?: any, deep?: number) {
        this.logger.fatal(message, object, deep);
    }
}