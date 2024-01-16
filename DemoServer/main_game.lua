---__init__
if _G["__init__"] then
    local arg = ...
    return {
        thread = 16,
        enable_stdout = true,
        logfile = string.format("log/game-%s-%s.log", arg[1], os.date("%Y-%m-%d-%H-%M-%S")),
        loglevel = "DEBUG",
        path = table.concat({
            "./?.lua",
            "./?/init.lua",
            "automatix-realtime/lualib/?.lua",
            "automatix-realtime/service/?.lua",
            -- Append your lua module search path
        }, ";")
    }
end
